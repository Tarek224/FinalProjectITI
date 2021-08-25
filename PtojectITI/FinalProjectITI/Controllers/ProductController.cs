using FinalProjectITI.Data;
using FinalProjectITI.Models;
using FinalProjectITI.Services;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using FinalProjectITI.ViewModel;

namespace FinalProjectITI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IBaseService<Product> baseService;
        private readonly IFilterService<Product> filterService;
        private readonly UserManager<IdentityUser> userManager;
        private readonly ApplicationDbContext context;

        public ProductController(IBaseService<Product> baseService, IFilterService<Product> filterService,UserManager<IdentityUser> userManager , ApplicationDbContext context)
        {
            this.baseService = baseService;
            this.filterService = filterService;
            this.userManager = userManager;
            this.context = context;
        }
        public IActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 16;
            var products = baseService.GetAll().ToPagedList(pageNumber, pageSize);
            ViewBag.Categories = context.Categories.ToList();
            ViewBag.Tags = context.Tags.ToList();
            return View(products);
        }
        public IActionResult ProductsInCategory(int id , int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 16;
            var products = filterService.FilterByCategory(id).ToPagedList(pageNumber, pageSize);
            ViewBag.Categories = context.Categories.ToList();
            ViewBag.Tags = context.Tags.ToList();
            return View("Index", products);
        }
        public IActionResult SortProducts(int id , int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 16;
            var products = filterService.SortingItems(id).ToPagedList(pageNumber, pageSize);
            ViewBag.Categories = context.Categories.ToList();
            ViewBag.Tags = context.Tags.ToList();
            return View("Index", products);
        }
        public IActionResult ProductsWithPrice(int id , int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 16;
            var products = filterService.FilterByPrice(id).ToPagedList(pageNumber, pageSize);
            ViewBag.Categories = context.Categories.ToList();
            ViewBag.Tags = context.Tags.ToList();
            return View("Index", products);
        }
        public IActionResult ProductsInTags(int id , int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 16;
            var products = filterService.FilterByTags(id).ToPagedList(pageNumber, pageSize);
            ViewBag.Categories = context.Categories.ToList();
            ViewBag.Tags = context.Tags.ToList();
            return View("Index", products);
        }
        public IActionResult ProductSearch(string name , int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 16;
            var products = baseService.Search(name).ToPagedList(pageNumber, pageSize);
            ViewBag.Categories = context.Categories.ToList();
            ViewBag.Tags = context.Tags.ToList();
            return View("Index", products);
        }
        public IActionResult Details(int id)
        {
            Product product = baseService.GetByID(id);
            product.Popularity += 1;
            context.SaveChanges();

            ViewBag.RelatedProducts = context.Products.Include(model => model.Images)
                .Where(model => model.Category_ID == product.Category_ID)
                .Take(8).ToList();

            return View(product);
        }
        [Authorize]
        public async Task<IActionResult> AddWishList(int id)
        {
            var user = await userManager.FindByEmailAsync(User.Identity.Name);
            Product product = baseService.GetByID(id);
            foreach (var item in context.UserWishLists.ToList())
            {
                if (item.Product_ID == product.Product_ID)
                {
                    return RedirectToAction("Index");
                }
            }
            UserWishList userWishList = new UserWishList
            {
                Customer_ID = user.Id,
                Product_ID = product.Product_ID
            };
            context.UserWishLists.Add(userWishList);
            context.SaveChanges();
            return RedirectToAction("UserWishList");
        }
        [Authorize]
        public async Task<IActionResult> UserWishList()
        {
            var user = await userManager.FindByEmailAsync(User.Identity.Name);
            var wishlist = context.UserWishLists.Include(model => model.Product)
                .ThenInclude(model => model.Images)
                .Where(model => model.Customer_ID == user.Id).ToList();

            return View(wishlist);
        }
        [Authorize]
        // id =============> UserWishList ID
        public IActionResult DeleteFromWishList(int id)
        {
            UserWishList wishListItem = context.UserWishLists.FirstOrDefault(model => model.UserWishList_ID == id);
            context.UserWishLists.Remove(wishListItem);
            context.SaveChanges();
            return RedirectToAction("UserWishList");
        }
    }
}
