using Product.API.Infrastructure;
using Product.API.Models;

namespace Product.API.Services;

public class ProductReposiory : GenericRepository<ProductEntity>, IProductRepository
{
    public ProductReposiory(ProductDBContext dbContext)
           : base(dbContext)
    {
    }
}