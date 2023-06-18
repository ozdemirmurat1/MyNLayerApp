using Microsoft.AspNetCore.Mvc;
using NLayer.Web.Services;

namespace NLayer.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoryApiService _categoryApiService;

        public CategoriesController(CategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
        }

        public async Task<IActionResult> Index()
        {
            var customResponse=await _categoryApiService.GetAllAsync();
            return View(customResponse);
        }
    }
}
