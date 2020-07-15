using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using NcNews.Data;
using NcNews.Dtos;
using NcNews.Models;

namespace NcNews.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentController : Controller
    {
        private readonly ICommentRepo _commentRepo;
        private readonly IMapper _mapper;

        public CommentController(ICommentRepo commentRepo, IMapper mapper)
        {
            _commentRepo = commentRepo;
            _mapper = mapper;
        }

        [HttpPatch("{id}")]
        public ActionResult UpdateComment(int id, [FromBody] JsonPatchDocument<Comments> patchDoc)
        {
            Comments comment = _commentRepo.GetCommentById(id);

            if (comment == null)
            {
                return NotFound();
            }

            Comments commentDto = _mapper.Map<Comments>(comment);

            patchDoc.ApplyTo(commentDto);

            _mapper.Map(commentDto, comment);

            _commentRepo.Save();

            return NoContent();

        }

    }

}
