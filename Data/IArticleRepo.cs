using System;
using System.Collections.Generic;
using NcNews.Models;

namespace NcNews.Data
{
 public interface IArticleRepo
 {
  IEnumerable<Articles> GetAllArticles();
  Articles GetArticleById(int id);
  IEnumerable<Comments> GetCommentByArticleId(int id);
  void PostComment(Comments comment);
  void PatchArticle(Articles article);
  void Save();

 }
}
