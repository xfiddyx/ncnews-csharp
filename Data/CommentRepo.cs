using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NcNews.Models;

namespace NcNews.Data
{
    public class CommentRepo : ICommentRepo
    {

        private readonly NcNewsContext _context;

        public CommentRepo(NcNewsContext context)
        {
            _context = context;

        }

        public IEnumerable<Comments> GetAllComments()
        {
            return _context.Comment.ToList();
        }

        public Comments GetCommentById(int id)
        {
            return _context.Comment.Find(id);
        }
        public void UpdateComment(Comments comment)
        {
            _context.Entry(comment).State = EntityState.Modified;

        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
