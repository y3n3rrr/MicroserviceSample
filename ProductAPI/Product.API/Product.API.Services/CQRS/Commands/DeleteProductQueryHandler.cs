using System;
using AutoMapper;
using MediatR;
using Product.API.Infrastructure;
using Product.API.Models;

namespace Product.API.Services
{
    public class DeleteProductQueryHandler : IRequestHandler<DeleteProductQuery, ProductDTO>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public DeleteProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Handle(DeleteProductQuery request, CancellationToken cancellationToken)
        {
            var entity = await _productRepository.GetById(request.Id);
            if (entity != null)
            {
                await _productRepository.Delete(request.Id);
            }
            var result = _mapper.Map<ProductDTO>(entity);
            return result;
        }
    }
}