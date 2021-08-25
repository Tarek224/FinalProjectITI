using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProjectITI.Data;
using FinalProjectITI.Models;
using FinalProjectITI.Services;
using Microsoft.AspNetCore.Authorization;
using FinalProjectITI.ViewModel;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace FinalProjectITI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IBaseService<Product> productservice;
        private readonly IBaseService<Category> categoryservice;


        public ProductController(ApplicationDbContext db, IBaseService<Product> productservice, IBaseService<Category> categoryservice)
        {
            this.db = db;
            this.productservice = productservice;
            this.categoryservice = categoryservice;

        }

        // GET: Admin/Product
        public IActionResult Index()
        {
            ViewBag.categ = categoryservice.GetAll();

            return View(productservice.GetAll());
        }

        // GET: Admin/Product/Details/5
        public IActionResult Details(int id)
        {
            ViewBag.categ = categoryservice.GetAll();
            return View(productservice.GetByID(id));
        }

        // GET: Admin/Product/Create
        public IActionResult Create()
        {
            // ViewData["Category_ID"] = new SelectList(categoryservice.GetAll());
            //ViewData["Images_ID"] = new SelectList(imageservice.GetAll());

            ViewBag.categ = categoryservice.GetAll();
            return View();
        }

        // POST: Admin/Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductImage product, List<IFormFile> files)
        {

            Product NewProd = new Product
            {
                Adding_Date = product.Adding_Date,
                Category_ID = product.Category_ID,
                Description = product.Description,
                Product_ID = product.Product_ID,
                Popularity = product.Popularity,
                Product_Size = product.Product_Size,
                Product_Color = product.Product_Color,
                Product_Name = product.Product_Name,
                Stored_Quantity = product.Stored_Quantity,
                Product_Price = product.Product_Price
            };
            try
            {
                db.Products.Add(NewProd);
                db.SaveChanges();

                /// Upload Images
                /// 
                List<string> imgList = new List<string>();
                foreach (var item in files)
                {
                    string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(item.FileName);

                    //Get url To Save
                    string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Products/", ImageName);

                    using (var stream = new FileStream(SavePath, FileMode.Create))
                    {
                        item.CopyTo(stream);
                    }
                    imgList.Add(ImageName);
                }

                ///

                Images imgs = new Images
                {
                    Image1 = imgList[0],
                    Image2 = imgList[1],
                    Image3 = imgList[2]
                };

                db.Images.Add(imgs);
                db.SaveChanges();

                NewProd.Images_ID = imgs.Images_ID;
                db.SaveChanges();

                ViewBag.categ = categoryservice.GetAll();



                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(product);
            }

        }

        // GET: Admin/Product/Edit/5
        public IActionResult Edit(int id)
        {
            ViewBag.categ = categoryservice.GetAll();

            var product = productservice.GetByID(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.prods = productservice.GetByID(id);

            return View(product);
        }

        // POST: Admin/Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Product_ID,Product_Name,Category_ID,Description,Product_Price,Product_Size,Product_Color,Adding_Date,Popularity,Stored_Quantity")] Product product,List<IFormFile> files)
        {
            ViewBag.categ = categoryservice.GetAll();
           
            if (ModelState.IsValid)
            {
                try
                {
                    List<string> imgList = new List<string>();
                    foreach (var item in files)
                    {
                        string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(item.FileName);

                        //Get url To Save
                        string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Products", ImageName);

                        using (var stream = new FileStream(SavePath, FileMode.Create))
                        {
                            item.CopyTo(stream);
                        }
                        imgList.Add(ImageName);
                    }
                    Images imgs = new Images
                    {
                        Image1 = imgList[0],
                        Image2 = imgList[1],
                        Image3 = imgList[2],
                    };
                    db.Images.Add(imgs);
                    db.SaveChanges();
                    product.Images_ID = imgs.Images_ID;

                    productservice.Update(id, product);
                    //await _context.SaveChangesAsync();
                    //return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Product_ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["Category_ID"] = new SelectList(_context.Categories, "Category_ID", "Category_Name", product.Category_ID);

            return View(product);

        }

        // GET: Admin/Product/Delete/5
        public IActionResult Delete(int id)
        {
            ViewBag.categ = categoryservice.GetAll();


            var product = productservice.GetByID(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            productservice.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            var check = false;
            var item = productservice.GetByID(id);
            if (item != null)
            {
                check = true;
            }
            return check;
        }
    }
}
