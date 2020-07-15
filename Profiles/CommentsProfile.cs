using System;
using AutoMapper;
using NcNews.Dtos;
using NcNews.Models;

namespace NcNews.Profiles
{
    public class CommentsProfile : Profile
    {
        public CommentsProfile()
        {
            CreateMap<UpdateCommentDto, Comments>();
            CreateMap<Comments, UpdateCommentDto>();
            //void DeleteComment(Comments comment);
        }
    }
}
