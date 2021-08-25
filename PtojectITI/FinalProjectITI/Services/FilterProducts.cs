using FinalProjectITI.Data;
using FinalProjectITI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectITI.Services
{
    public class FilterProducts : IFilterService<Product>
    {
        private readonly ApplicationDbContext context;

        public FilterProducts(ApplicationDbContext context)
        {
            this.context = context;
        }
        public List<Product> FilterByCategory(int id)
        {
            List<Product> products = context.Products.Include(model => model.Images).Where(model => model.Category_ID == id).ToList();
            return products;
        }
        public List<Product> FilterByPrice(int id)
        {
            List<Product> products;
            switch (id)
            {
                case (1):
                    products = context.Products.Include(model => model.Images).Where(model => model.Product_Price > 0 && model.Product_Price <= 100).ToList();
                    break;
                case (2):
                    products = context.Products.Include(model => model.Images).Where(model => model.Product_Price > 100 && model.Product_Price <= 150).ToList();
                    break;
                case (3):
                    products = context.Products.Include(model => model.Images).Where(model => model.Product_Price > 150 && model.Product_Price <= 200).ToList();
                    break;
                case (4):
                    products = context.Products.Include(model => model.Images).Where(model => model.Product_Price > 200).ToList();
                    break;
                default:
                    products = context.Products.Include(model => model.Images).ToList();
                    break;
            }
            return products;
        }
        public List<Product> FilterByTags(int id)
        {
            List<Product> products = context.ProductTags.Where(model => model.Tag_ID == id)
                                    .Include(model => model.Product).ThenInclude(model => model.Images)
                                    .Select(model => model.Product).ToList();
            return products;
        }
        public List<Product> SortingItems(int id)
        {
            List<Product> products;
            switch (id)
            {
                case (1):
                    products = context.Products.Include(model => model.Images)
                            .OrderByDescending(model => model.Popularity).ToList();
                    break;
                case (2):
                    products = context.Products.Include(model => model.Images)
                            .OrderByDescending(model => model.Adding_Date).ToList();
                    break;
                case (3):
                    products = context.Products.Include(model => model.Images)
                            .OrderBy(model => model.Product_Price).ToList();
                    break;
                case (4):
                    products = context.Products.Include(model => model.Images)
                            .OrderByDescending(model => model.Product_Price).ToList();
                    break;
                default:
                    products = context.Products.Include(model => model.Images).ToList();
                    break;
            }
            return products;
        }
    }
}
