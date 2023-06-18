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
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork,ICategoryRepository categoryRepository,IMapper mapper) : base(repository, unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<CategoryWithProductsDto>>> GetCategoryWithProducts()
        {
            var categories = await _categoryRepository.GetCategoryWithProducts();

            var categoriesDto=_mapper.Map<List<CategoryWithProductsDto>>(categories);

            return CustomResponseDto<List<CategoryWithProductsDto>>.Success(200, categoriesDto);
        }

        public async Task<CustomResponseDto<CategoryWithProductsDto>> GetSingleCategoryByIdWithProductsAsync(int id)
        {
            var category = await _categoryRepository.GetSingleCategoryByIdWithProductsAsync(id);

            var categoryDto=_mapper.Map<CategoryWithProductsDto>(category);

            return CustomResponseDto<CategoryWithProductsDto>.Success(200, categoryDto);
        }
    }
}
