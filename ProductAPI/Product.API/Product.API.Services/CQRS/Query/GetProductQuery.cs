using System;
using MediatR;
using Product.API.Models;

namespace Product.API.Services
{
    public class GetProductQuery : IRequest<ProductDTO>
    {
        public int Id { get; set; }
    }
}