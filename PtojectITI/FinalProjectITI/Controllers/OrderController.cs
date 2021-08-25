using FinalProjectITI.Data;
using FinalProjectITI.Models;
using FinalProjectITI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectITI.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IBaseService<Product> baseService;
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;

        public OrderController(IBaseService<Product> baseService , ApplicationDbContext context , UserManager<IdentityUser> userManager)
        {
            this.baseService = baseService;
            this.context = context;
            this.userManager = userManager;
        }
        [NonAction]
        public decimal CalcualteTotal(ICollection<OrderDetails> orderDetails)
        {
            decimal result = 0;
            if (orderDetails.Count != 0)
            {
                foreach (var item in orderDetails)
                {
                    result += item.Total_price;
                }
            }
            return result;
        }

        // id ==========> Product ID
        [HttpPost]
        public async Task<IActionResult> AddToCart(int id , int quantity , [Bind(include:"Product_Color , Product_Size")] Product prod)
        {
            IdentityUser user = await userManager.FindByEmailAsync(User.Identity.Name);
            Product product = baseService.GetByID(id);
            List<Order> orders = context.Orders.ToList();
            bool found = false;
            foreach (var item in orders)
            {
                if (item.Customer_ID == user.Id)
                {
                    found = true;
                    break;
                }
                else
                {
                    continue;
                }
            }
            if (found == false)
            {
                Order order = new Order()
                {
                    Customer_ID = user.Id,
                    Order_Total = product.Product_Price * quantity,
                    Order_Status = 0,
                };
                context.Orders.Add(order);
                context.SaveChanges();
                OrderDetails orderDetails = new OrderDetails
                {
                    Order_ID = order.Order_ID,
                    Product_ID = product.Product_ID,
                    Product_Quantity = quantity,
                    Total_price = product.Product_Price * quantity,
                    Product_Color = prod.Product_Color,
                    Product_Size = prod.Product_Size
                };
                context.OrderDetails.Add(orderDetails);
                context.SaveChanges();
                return RedirectToAction("Details","Product",new { id = product.Product_ID});
            }
            else
            {
                var order = context.Orders.Include(model => model.OrderDetails)
                    .FirstOrDefault(model => model.Customer_ID == user.Id);

                bool isFound = false;

                foreach (var item in order.OrderDetails)
                {
                    if (item.Product_ID == product.Product_ID)
                    {
                        isFound = true;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (isFound)
                {
                    OrderDetails orderDetails = context.OrderDetails
                        .FirstOrDefault(model => model.Product_ID == product.Product_ID);

                    orderDetails.Product_Quantity = quantity;
                    orderDetails.Total_price = orderDetails.Product_Quantity * product.Product_Price;
                    context.SaveChanges();

                    order.Order_Total = CalcualteTotal(order.OrderDetails);
                    context.SaveChanges();
                    return RedirectToAction("Details", "Product", new { id = product.Product_ID });
                }
                else
                {
                    OrderDetails orderDetails = new OrderDetails()
                    {
                        Order_ID = order.Order_ID,
                        Product_ID = product.Product_ID,
                        Product_Quantity = quantity,
                        Total_price = product.Product_Price * quantity,
                        Product_Color = prod.Product_Color,
                        Product_Size = prod.Product_Size
                    };
                    context.OrderDetails.Add(orderDetails);
                    context.SaveChanges();

                    order.Order_Total = CalcualteTotal(order.OrderDetails);
                    context.SaveChanges();
                    return RedirectToAction("Details", "Product", new { id = product.Product_ID });
                }
            }
        }

        public async Task<IActionResult> Cart()
        {
            IdentityUser user = await userManager.FindByEmailAsync(User.Identity.Name);
            Order order = context.Orders.Include(model => model.OrderDetails)
                .ThenInclude(model => model.Product).ThenInclude(model => model.Images)
                .FirstOrDefault(model => model.Customer_ID == user.Id);
            if(order==null)
            {
                Order ord = new Order { 
                Customer_ID = user.Id
                
                };
                context.Orders.Add(ord);
                context.SaveChanges();
            }
            ViewBag.Total = order.Order_Total + 5;
            return View(order);
        }
        public async Task<IActionResult> UpdateCart(IEnumerable<OrderDetails> orderDetails)
        {
            List<OrderDetails> orders = orderDetails.ToList();
            IdentityUser user = await userManager.FindByEmailAsync(User.Identity.Name);
            Order ord = context.Orders.Include(m => m.OrderDetails).ThenInclude(m=>m.Product).FirstOrDefault(m=>m.Customer_ID==user.Id);
            for (int i = 0; i < ord.OrderDetails.Count; i++)
            {
                if (orders[i] != ord.OrderDetails[i])
                {
                    ord.OrderDetails[i].Product_Quantity = orders[i].Product_Quantity;
                    ord.OrderDetails[i].Total_price = orders[i].Product_Quantity * ord.OrderDetails[i].Product.Product_Price;
                    context.SaveChanges();
                    ord.Order_Total = CalcualteTotal(ord.OrderDetails);
                    context.SaveChanges();

                }
            }

            return RedirectToAction("Cart");
        }
        // id ================> OrderDetails Id
        public IActionResult DeleteFromCart(int id)
        {
            OrderDetails orderDetails = context.OrderDetails.Include(model => model.Order)
                .FirstOrDefault(model => model.OrderDetails_ID == id);

            orderDetails.Order.Order_Total -= orderDetails.Total_price;
            context.SaveChanges();

            context.OrderDetails.Remove(orderDetails);
            context.SaveChanges();

            return RedirectToAction("Cart");
        }
        [HttpPost]
        public async Task<IActionResult> CheckOut(Shipping ship)
        {
            Shipping shipping = new Shipping()
            {
                Address = ship.Address,
                Phone = ship.Phone,
                Postal_Code = ship.Postal_Code,
                Shipper_Email = ship.Shipper_Email,
                Shipper_Name = ship.Shipper_Name,
            };
            context.Shippings.Add(shipping);
            context.SaveChanges();

            IdentityUser user = await userManager.FindByEmailAsync(User.Identity.Name);
            Order order = context.Orders.FirstOrDefault(model => model.Customer_ID == user.Id);
            order.Shipping_ID = shipping.Shipping_ID;
            context.SaveChanges();

            List<OrderDetails> orderDetails = context.OrderDetails.Include(model => model.Product)
                .Where(model => model.Order_ID == order.Order_ID).ToList();

            foreach (var item in orderDetails)
            {
                item.Product.Stored_Quantity -= item.Product_Quantity;
            }

            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
