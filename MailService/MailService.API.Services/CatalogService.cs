using Catalog.API.Infrastructure;
using Catalog.API.Models;

namespace Catalog.API.Services;

public class CatalogService : ICatalogService
{
    public CatalogDTO GetCatalogById(int Id)
    {
        return new CatalogDTO
        {
            Id = Id,
            Name = "test"
        };
    }
}

