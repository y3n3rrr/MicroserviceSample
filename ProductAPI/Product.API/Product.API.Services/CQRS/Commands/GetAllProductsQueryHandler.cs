using System;
using AutoMapper;
using MediatR;
using Product.API.Infrastructure;
using Product.API.Models;

namespace Product.API.Services
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDTO>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var data = await _productRepository.GetAll();
            var result = _mapper.Map<List<ProductDTO>>(data);
            return result;
        }
    }
}