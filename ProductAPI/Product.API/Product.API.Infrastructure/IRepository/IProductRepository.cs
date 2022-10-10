using System;
using Product.API.Models;

namespace Product.API.Infrastructure
{
    public interface IProductRepository : IGenericRepository<ProductEntity>
    {
    }
}