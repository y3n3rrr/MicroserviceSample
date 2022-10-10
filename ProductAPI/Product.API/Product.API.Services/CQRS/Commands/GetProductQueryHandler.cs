using System;
using AutoMapper;
using MediatR;
using Product.API.Infrastructure;
using Product.API.Models;

namespace Product.API.Services
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDTO>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var data = await _productRepository.GetById(request.Id);
            var result = _mapper.Map<ProductDTO>(data);
            return result;
        }
    }
}