using FinalProjectITI.Data;
using FinalProjectITI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectITI.Services
{
    public class ProductService : IBaseService<Product>
    {
        private readonly ApplicationDbContext context;

        public ProductService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Add(Product model)
        {
            context.Products.Add(model);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Product product = context.Products.FirstOrDefault(prod => prod.Product_ID == id);
            context.Products.Remove(product);
            context.SaveChanges();
        }

        public List<Product> GetAll()
        {
            List<Product> products = context.Products.Include(m => m.Images).ToList();
            return products;
        }
        public Product GetByID(int id)
        {
            Product product = context.Products.Include(model => model.Images).FirstOrDefault(prod => prod.Product_ID == id);
            return product;
        }

        public List<Product> Search(string name)
        {
            List<Product> products = context.Products.Where(prod => prod.Product_Name.Contains(name)).Include(model => model.Images).ToList();
            return products;
        }

        public void Update(int id, Product model)
        {
            Product product = context.Products.FirstOrDefault(prod => prod.Product_ID == id);
            product.Category_ID = model.Category_ID;
            product.Description = model.Description;
            product.Product_Color = model.Product_Color;
            product.Product_Name = model.Product_Name;
            product.Product_Price = model.Product_Price;
            product.Product_Size = model.Product_Size;
            product.Images_ID = model.Images_ID;
            context.SaveChanges();
        }
        public List<Category> GetCategories()
        {
            return context.Categories.ToList();
        }
        public List<Tags> GetTags()
        {
            return context.Tags.ToList();
        }
    }
}
