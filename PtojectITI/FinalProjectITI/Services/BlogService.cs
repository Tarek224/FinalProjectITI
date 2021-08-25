using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectITI.Data;
using FinalProjectITI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectITI.Models
{
    public class BlogService : IBaseService<Blog>
    {
        private readonly ApplicationDbContext context;

        public BlogService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public void Add(Blog model)
        {
            context.Blogs.Add(model);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Blogs.Remove(context.Blogs.FirstOrDefault(b => b.Blog_ID == id));
            context.SaveChanges();
        }

        public List<Blog> GetAll()
        {
            return context.Blogs.Include(d => d.Comments)
                .Include(d => d.BlogTags)
                .ThenInclude(d => d.Tags).ToList();
        }

        public Blog GetByID(int id)
        {
            return context.Blogs.Include(d=>d.Comments)
                .Include(d=>d.BlogTags)
                .ThenInclude(d=>d.Tags)
                .FirstOrDefault(b => b.Blog_ID == id);
        }

        public List<Blog> Search(string name)
        {
            return context.Blogs.Where(b => b.Blog_Title.Contains(name))
                .Include(d => d.Comments)
                .Include(d => d.BlogTags)
                .ThenInclude(d => d.Tags).ToList();
        }

        public void Update(int id, Blog model)
        {
            Blog blog = context.Blogs.FirstOrDefault(d => d.Blog_ID == id);
            blog.Blog_Title = model.Blog_Title;
            blog.Blog_Content = model.Blog_Content;
            blog.Blog_Date = model.Blog_Date;
            blog.Blog_Image = model.Blog_Image;
            context.SaveChanges();
        }
    }
}
