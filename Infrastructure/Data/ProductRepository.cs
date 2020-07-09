using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data {
    public class ProductRepository : IProductRepository 
    {
        private readonly StoreContext _context;
        public ProductRepository (StoreContext context) 
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
            throw new System.NotImplementedException();
        }

        public async Task<Product> GetProductByIdAsync (int id) 
        {
            var products= await _context.Products
            .Include(p => p.ProductType)
            .Include(p => p.ProductBrand)
            .FirstOrDefaultAsync(p => p.Id == id);
            return products;

            throw new System.NotImplementedException ();
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync ()
        {
            var products = await _context.Products
            .Include(p => p.ProductType)
            .Include(p => p.ProductBrand)
            .ToListAsync();
            return products;
            throw new System.NotImplementedException ();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
            throw new System.NotImplementedException();
        }
    }
}