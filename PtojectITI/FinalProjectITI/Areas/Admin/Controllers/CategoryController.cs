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

namespace FinalProjectITI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly IBaseService<Category> categoryservice;

        public CategoryController(IBaseService<Category> categoryservice)
        {
            this.categoryservice = categoryservice;
        }

        // GET: Admin/Category
        public IActionResult Index()
        {
            ViewBag.categories_Names = categoryservice.GetAll();
            return View( categoryservice.GetAll());
        }

        // GET: Admin/Category/Details/5
        public IActionResult Details(int id)
        {
            return View(categoryservice.GetByID(id));
        }

        // GET: Admin/Category/Create
        public IActionResult Create()
        {
            ViewBag.categories_Names = categoryservice.GetAll();
            return View();
        }

        // POST: Admin/Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Category_ID,Category_Name,Category_Describtion")] Category category)
        {
            ViewBag.categories_Names = categoryservice.GetAll();
            
            if (!ModelState.IsValid)
                return View(category);
            try
            {
                categoryservice.Add(category);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(category);
            }
        }

        // GET: Admin/Category/Edit/5
        public IActionResult Edit(int id)
        {
            var category = categoryservice.GetByID(id);
            if (category == null)
            {
                return NotFound();
            }
            ViewBag.categories_Names = categoryservice.GetByID(id);
            return View(category);
        }

        // POST: Admin/Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Category_ID,Category_Name,Category_Describtion")] Category category)
        {
            if (id != category.Category_ID)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                try
                {
                    categoryservice.Update(id, category);
                    //await _context.SaveChangesAsync();
                    //return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Category_ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction( nameof(Index));

            }
            return View(category);
        }

            // GET: Admin/Category/Delete/5
            public IActionResult Delete(int id)
        {
            var product = categoryservice.GetByID(id);
            if (product == null)
            {
                return NotFound();
            }

            // categoryservice.Delete(id);
            return View(product);
        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            categoryservice.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            var check = false;
            var item = categoryservice.GetByID(id);
            if (item != null)
            {
                check = true;
            }
            return check;
        }

        public IActionResult CategorySearch(string name)
        {
            List<Category> categ = categoryservice.Search(name);
            return View(categ);
        }
    }
}
