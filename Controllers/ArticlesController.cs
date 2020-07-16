using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using NcNews.Data;
using NcNews.Dtos;
using NcNews.Models;

namespace NcNews.Controllers
{

 [Route("api/articles")]
 [ApiController]
 public class ArticlesController : Controller
 {
  private readonly IMapper _mapper;
  private readonly IArticleRepo _articleRepo;

  public ArticlesController(IArticleRepo articleRepo, IMapper mapper)
  {
   _articleRepo = articleRepo;
   _mapper = mapper;
  }
  //comment

  [HttpGet]
  public ActionResult<IEnumerable<Articles>> GetAllArticles()
  {
   var result = _articleRepo.GetAllArticles();

   return Ok(_mapper.Map<IEnumerable<ReadArticleDto>>(result));
  }

  [HttpGet("{id}")]
  public ActionResult<Articles> GetArticleById(int id)
  {

   var result = _articleRepo.GetArticleById(id);

   if (result == null)
   {
    string message = "This user does not exist";
    throw new ArgumentException(message);
   }
   return Ok(_mapper.Map<ReadArticleDto>(result));
  }

  [HttpPatch("{id}")]
  public ActionResult PatchArticle(int id,
      [FromBody] JsonPatchDocument<UpdateCommentDto> patchDoc)
  {
   Articles article = _articleRepo.GetArticleById(id);

   if (article == null)
   {
    return NotFound();
   }

   var articleDto = _mapper.Map<UpdateCommentDto>(article);

   patchDoc.ApplyTo(articleDto);

   _mapper.Map(articleDto, article);

   _articleRepo.Save();

   return NoContent();

  }
  [HttpGet("{id}/comments", Name = "GetCommentById")]
  public ActionResult<IEnumerable<ReadCommentsDto>> GetCommentById(int id)
  {
   var result = _articleRepo.GetCommentByArticleId(id);

   return Ok(_mapper.Map<IEnumerable<ReadCommentsDto>>(result));
  }

  [HttpPost("{id}/comments")]
  public ActionResult<ReadCommentsDto> PostComment(CreateCommentDto createCommentDto)
  {
   var commentModel = _mapper.Map<Comments>(createCommentDto);

   _articleRepo.PostComment(commentModel);
   _articleRepo.Save();

   var commentReadDto = _mapper.Map<ReadCommentsDto>(commentModel);

   return CreatedAtRoute(nameof(GetCommentById), new { id = commentReadDto.id }, commentReadDto);

  }


 }
}
