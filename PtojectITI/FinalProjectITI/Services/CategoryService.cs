using FinalProjectITI.Data;
using FinalProjectITI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectITI.Services
{
    public class CategoryService : IBaseService<Category>
    {
        private readonly ApplicationDbContext context;

        public CategoryService(ApplicationDbContext context)
        {
            this.context = context;
        }


        public void Add(Category model)
        {
            context.Categories.Add(model);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Category category = context.Categories.FirstOrDefault(categ => categ.Category_ID == id);
            context.Categories.Remove(category);
            context.SaveChanges();
        }

        public List<Category> GetAll()
        {
            List<Category> categories = context.Categories.ToList();
            return categories;
        }
        public Category GetByID(int id)
        {
            Category category = context.Categories.FirstOrDefault(categ => categ.Category_ID == id);
            return category;
        }

        //For Products Only
        public List<Category> Search(string name)
        {
            List<Category> products = context.Categories.Where(prod => prod.Category_Name.Contains(name)).ToList();
            return products;
        }

        //Not Completed
        public void Update(int id, Category model)
        {
            Category category = context.Categories.FirstOrDefault(categ => categ.Category_ID == id);

            category.Category_Name = model.Category_Name;
            category.Category_Describtion = model.Category_Describtion;
            //---product
            List<Product> products = context.Products.Where(prod => prod.Category_ID==id).ToList();
            foreach(var item in products)
            {
                item.Category_ID = id;
            }
            context.SaveChanges();
        }
    }
}
