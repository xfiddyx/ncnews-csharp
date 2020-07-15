using System;
using AutoMapper;
using NcNews.Dtos;
using NcNews.Models;

namespace NcNews.Profiles
{
    public class ArticleProfile : Profile
    {

        public ArticleProfile()
        {

            CreateMap<Articles, ReadArticleDto>();
            CreateMap<Articles, UpdateArticleDto>();
            CreateMap<UpdateArticleDto, Articles>();
            CreateMap<Comments, ReadCommentsDto>();
            CreateMap<Comments, CreateCommentDto>();
            CreateMap<CreateCommentDto, Comments>();

        }
    }
}
