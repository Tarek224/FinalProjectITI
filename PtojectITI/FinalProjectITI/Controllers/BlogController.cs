using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectITI.Data;
using FinalProjectITI.Models;
using FinalProjectITI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectITI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBaseService<Blog> blog_Service;
        private readonly IBaseService<Comment> commentService;
        private readonly UserManager<IdentityUser> userManager;

        public BlogController(IBaseService<Blog> blog_service, IBaseService<Comment> commentService , UserManager<IdentityUser> userManager )
        {
            blog_Service = blog_service;
            this.commentService = commentService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(blog_Service.GetAll());
        }

        public IActionResult BlogDetails(int id)
        {
            return View(blog_Service.GetByID(id));
        }

        public IActionResult Search(string name)
        {
            return View("Index", blog_Service.Search(name));
        }

        [HttpPost]
        public async Task<IActionResult> AddComment([Bind("Text")] Comment model, int id)
        {
            var user = await userManager.FindByEmailAsync(User.Identity.Name);
            model.Customer_ID = user.Id;
            model.Blog_ID = id;
            model.Comment_Date = DateTime.Now;
            commentService.Add(model);
            return RedirectToAction("BlogDetails", new { id = id });
        }

        public IActionResult Archive(int year)
        {
            List<Blog> list = new List<Blog>();
            foreach (var item in blog_Service.GetAll())
            {
                if (item.Blog_Date.Year == year)
                {
                    list.Add(item);
                }
            }
            return View("Index", list);
        }
    }
}
