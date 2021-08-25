using FinalProjectITI.Data;
using FinalProjectITI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectITI.Services
{
    public class ImageService : IBaseService<Images>
    {
        private readonly ApplicationDbContext context;

        public ImageService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(Images model)
        {
            context.Images.Add(model);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Images img = context.Images.FirstOrDefault(im => im.Images_ID == id);
            context.Images.Remove(img);
            context.SaveChanges();
        }

        public List<Images> GetAll()
        {
            List<Images> imgs = context.Images.ToList();
            return imgs;
        }

        public Images GetByID(int id)
        {
            Images img = context.Images.FirstOrDefault(im => im.Images_ID == id);
            return img;
        }

        public List<Images> Search(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Images model)
        {
            Images img = context.Images.FirstOrDefault(im => im.Images_ID==id);

            img.Image1 = model.Image1;
            img.Image2 = model.Image2;
            img.Image3 = model.Image3;

            List<Product> products = context.Products.Where(prod => prod.Images_ID == id).ToList();
            foreach (var item in products)
            {
                item.Images_ID = id;
            }

            context.SaveChanges();
        }
    }
}
