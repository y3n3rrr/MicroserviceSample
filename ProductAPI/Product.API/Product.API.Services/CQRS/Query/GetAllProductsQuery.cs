using System;
using MediatR;
using Product.API.Models;

namespace Product.API.Services
{
    public class GetAllProductsQuery : IRequest<List<ProductDTO>>
    {
    }
}

