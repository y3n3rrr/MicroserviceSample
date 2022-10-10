using Microsoft.AspNetCore.Http;

namespace Product.API.Models;

public class ProductPutRequestModel
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal Cost { get; set; }
    public IFormFile Image { get; set; }
}