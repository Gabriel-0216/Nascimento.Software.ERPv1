using Domain.Entities.Product;
using Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class ProductStockRepository : IRepository<ProductStock>
    {
        private readonly AppDbContext _context;
        public ProductStockRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(ProductStock entity)
        {
            _context.Add(entity);
            var teste = await _context.SaveChangesAsync();

            return teste > 0;
        }

        public Task<bool> Delete(ProductStock entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductStock>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<ProductStock?> GetOne(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(ProductStock entity)
        {
            throw new NotImplementedException();
        }
    }
}
