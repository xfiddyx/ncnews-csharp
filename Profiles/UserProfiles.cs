using System;
using AutoMapper;
using NcNews.Dtos;
using NcNews.Models;

namespace NcNews.Profiles
{
    public class UserProfiles : Profile
    {
        public UserProfiles()
        {
            CreateMap<Users, ReadUserDto>();
            CreateMap<Users, CreateUserDto>();
            CreateMap<CreateUserDto, Users>();
            CreateMap<UpdateUserDto, Users>();
            CreateMap<Users, UpdateUserDto>();

        }
    }
}