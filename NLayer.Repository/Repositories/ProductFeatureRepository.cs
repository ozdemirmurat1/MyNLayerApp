using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class ProductFeatureRepository : GenericRepository<ProductFeature>, IProductFeatureRepository
    {
        public ProductFeatureRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<ProductFeature> GetProductFeatureWithProduct(int id)
        {
            return await _context.ProductFeatures.Include(x=>x.Product).Where(x=>x.ProductId.Equals(id)).SingleOrDefaultAsync();
        }
    }
}
