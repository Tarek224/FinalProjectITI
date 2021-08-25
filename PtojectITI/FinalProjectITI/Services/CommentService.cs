using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectITI.Data;
using FinalProjectITI.Models;

namespace FinalProjectITI.Services
{
    public class CommentService : IBaseService<Comment>
    {
        private readonly ApplicationDbContext context;

        public CommentService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Add(Comment model)
        {
            context.Comments.Add(model);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Comments.Remove(context.Comments.FirstOrDefault(d => d.Comment_ID == id));
            context.SaveChanges();
        }

        public List<Comment> GetAll()
        {
            return context.Comments.ToList();
        }

        public Comment GetByID(int id)
        {
            return context.Comments.FirstOrDefault(d => d.Comment_ID == id);
        }

        public List<Comment> Search(string name)
        {
            return context.Comments.Where(d=>d.Text.Contains(name)).ToList();
        }

        public void Update(int id, Comment model)
        {
            Comment cmt = this.GetByID(id);
            cmt.Text = model.Text;
            context.SaveChanges();
        }
    }
}
