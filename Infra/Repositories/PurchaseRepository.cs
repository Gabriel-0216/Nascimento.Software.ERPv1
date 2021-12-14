using Domain.Entities.Purchases;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class PurchaseRepository : IRepository<Purchase>
    {
        private readonly AppDbContext _context;
        public PurchaseRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Purchase entity)
        {
            _context.Add(entity);
            int entriesDb = await _context.SaveChangesAsync();
            return entriesDb > 0;
        }

        public Task<bool> Delete(Purchase entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Purchase>> Get()
        {
            return await _context.Purchases
                .Include(p=> p.Buyer)
                .Include(p=> p.Products)
                .ThenInclude(p=> p.Purchases)
                .Include(p=> p.Payments)
                .ToListAsync();
        }

        public Task<Purchase?> GetOne(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Purchase entity)
        {
            throw new NotImplementedException();
        }
    }
}
