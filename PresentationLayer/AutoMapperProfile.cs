using AutoMapper;
using DataAccessLayer.Entities;
using PresentationLayer.DTOs;

namespace PresentationLayer
{
    // configuration for AutoMapper library
    // AutoMapper is used to map actual entity with DTO (Data Transfer Object)
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
