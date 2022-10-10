using System;
using MediatR;
using Product.API.Models;

namespace Product.API.Services
{
    public class DeleteProductQuery : IRequest<ProductDTO>
    {
        public int Id { get; set; }
    }
}