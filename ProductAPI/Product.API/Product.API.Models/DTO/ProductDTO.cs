﻿namespace Product.API.Models;
public class ProductDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal Cost { get; set; }
    public string ImagePath { get; set; }
}

