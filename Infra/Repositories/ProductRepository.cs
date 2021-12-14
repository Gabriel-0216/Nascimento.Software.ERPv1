using Domain.Entities.Product;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class ProductRepository : IRepository<Products>
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext Context)
        {
            _context = Context;
        }
        public async Task<bool> Add(Products entity)
        {
            int entriesDb = 0;

            _context.Add(entity);
            entriesDb = await _context.SaveChangesAsync();
            return entriesDb > 0;
        }
        public async Task<bool> Delete(Products entity)
        {
            int entriesDb = 0;

            _context.Remove(entity);
            entriesDb = await _context.SaveChangesAsync();
            return entriesDb > 0;
        }
        public async Task<IEnumerable<Products>> Get()
        {
            IQueryable<Products> query = _context.Products;

            await query.Include(p => p.ProductName)
                .ToListAsync();

            return query;
        }
        public async Task<Products?> GetOne(string Id)
        {
            IQueryable<Products> query = _context.Products;

            var q = await query.Include(p => p.ProductName).FirstOrDefaultAsync(p => p.Id == Id);
            return q;
        }
        public async Task<bool> Update(Products entity)
        {
            int entriesDb = 0;

            _context.Update(entity);
            entriesDb = await _context.SaveChangesAsync();
            return entriesDb > 0;
        }
    }
}
