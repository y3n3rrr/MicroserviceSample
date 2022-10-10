using System;
using System.Reflection;
using AutoMapper;
using EventBus.Base.Abstraction;
using EventBus.Base.Events;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Product.API.Infrastructure;
using Product.API.Models;

namespace Product.API.Services
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, ProductDTO>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IEventBus _eventBus;
        private IHostingEnvironment Environment;

        public CreateProductCommandHandler(IProductRepository productRepository, IEventBus eventBus, IMapper mapper, IHostingEnvironment _environment)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _eventBus = eventBus;
            Environment = _environment;
        }

        public async Task<ProductDTO> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = new ProductEntity
            {
                Name = request.Name,
                Price = request.Price,
                Cost = request.Cost.GetValueOrDefault(0),
            };

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

            await _productRepository.Create(entity);
            var result = _mapper.Map<ProductDTO>(entity);

            // ** Publish create event
            IntegrationEvent eventToPublish = new ProductCreatedIntegrationEvent(result.Id, productName: result.Name);
            _eventBus.Publish(eventToPublish).ContinueWith(t => Console.WriteLine(t.Exception), TaskContinuationOptions.OnlyOnFaulted);

            return result;
        }
    }
}