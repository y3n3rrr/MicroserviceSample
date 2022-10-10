using System;
using MediatR;
using Microsoft.AspNetCore.Http;
using Product.API.Models;

namespace Product.API.Services
{
    public class CreateProductCommand :   ICommand<ProductDTO>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal? Cost { get; set; }
        public IFormFile Image { get; set; }
    }
}