using System;
using System.Collections.Generic;
using NcNews.Models;

namespace NcNews.Data
{
    public interface ICommentRepo
    {
        IEnumerable<Comments> GetAllComments();
        Comments GetCommentById(int id);
        void UpdateComment(Comments comment);
        void Save();
    }
}
