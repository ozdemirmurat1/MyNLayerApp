using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductFeaturesController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductFeatureService _service;

        public ProductFeaturesController(IMapper mapper, IProductFeatureService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var productFeature=await _service.GetAllAsync();

            var productFeatureDto=_mapper.Map<List<ProductFeatureDto>>(productFeature.ToList());

            return CreateActionResult(CustomResponseDto<List<ProductFeatureDto>>.Success(200,productFeatureDto));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductFeatureWithProduct(int id)
        {
            return CreateActionResult(await _service.GetProductFeatureWithProduct(id));
        }


    }
}
