using System;
using AutoMapper;
using Product.API.Infrastructure;
using Product.API.Models;

namespace Product.API.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<ProductEntity, ProductDTO>();
            CreateMap<ProductDTO, ProductEntity>();
        }
    }
}

