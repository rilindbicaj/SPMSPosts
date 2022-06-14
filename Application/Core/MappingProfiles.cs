using Application.Requests;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {

            CreateMap<PostCreateRequest, Post>();

        }

    }
}