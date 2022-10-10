using System;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Product.API.Infrastructure;
using Product.API.Models;

namespace Product.API.Services
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDTO>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private IHostingEnvironment Environment;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper, IHostingEnvironment _environment)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            Environment = _environment;
        }

        public async Task<ProductDTO> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _productRepository.GetById(request.Id);
            if (entity != null)
            {
                entity.Name = request.Name;
                entity.Price = request.Price;
                entity.Cost = request.Cost;

                if (request.Image.Length > 0)
                {
                    string fileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(request.Image.FileName)}";
                    string filePath = Path.Combine(Environment.ContentRootPath, "Uploads", fileName);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await request.Image.CopyToAsync(fileStream);
                    }

                    entity.ImagePath = filePath;
                }

                await _productRepository.Update(request.Id, entity);
            }
            var result = _mapper.Map<ProductDTO>(entity);
            return result;
        }
    }
}