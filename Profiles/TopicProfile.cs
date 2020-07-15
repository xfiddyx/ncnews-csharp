using System;
using NcNews.Models;
using AutoMapper;
using NcNews.Dtos;

namespace NcNews.Profiles
{
    public class TopicProfile : Profile
    {
        public TopicProfile()
        {
            CreateMap<Topics, ReadTopicDto>();
        }
    }
}
