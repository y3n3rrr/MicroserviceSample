using System;
using Catalog.API.Models;

namespace Catalog.API.Infrastructure
{
    public interface ICatalogService
    {
        public CatalogDTO GetCatalogById(int Id);
    }
}

