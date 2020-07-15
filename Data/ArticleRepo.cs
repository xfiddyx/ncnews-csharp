using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NcNews.Models;

namespace NcNews.Data
{
 public class ArticleRepo : IArticleRepo
 {

  private readonly NcNewsContext _context;

  public ArticleRepo(NcNewsContext context)
  {
   _context = context;
  }

  public IEnumerable<Articles> GetAllArticles()
  {
   return _context.Article.ToList();


  }

  public Articles GetArticleById(int id)
  {
   return _context.Article.Find(id);
  }

  public void PatchArticle(Articles article)
  {
   _context.Entry(article).State = EntityState.Modified;
  }

  public IEnumerable<Comments> GetCommentByArticleId(int id)
  {
   var result = _context.User.Find(id);
   return _context.Comment.Where(u => u.articles_id == result.username).ToList();
  }

  public void PostComment(Comments comment)
  {
   _context.Comment.Add(comment);
  }

  public void Save()
  {
   _context.SaveChanges();
  }
 }
}
