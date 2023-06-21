using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class ProductFeatureService : Service<ProductFeature>, IProductFeatureService
    {
        private readonly IProductFeatureRepository _productFeatureRepository;
        private readonly IMapper _mapper;
        public ProductFeatureService(IGenericRepository<ProductFeature> repository, IUnitOfWork unitOfWork, IProductFeatureRepository productFeatureRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _productFeatureRepository = productFeatureRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<ProductFeatureWithProductDto>> GetProductFeatureWithProduct(int id)
        {
            var productFeature=await _productFeatureRepository.GetProductFeatureWithProduct(id);

            var productFeatureDto = _mapper.Map<ProductFeatureWithProductDto>(productFeature);

            return CustomResponseDto<ProductFeatureWithProductDto>.Success(200, productFeatureDto);
        }
    }
}
