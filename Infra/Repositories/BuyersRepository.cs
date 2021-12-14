using Domain.Entities.Buyer;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class BuyersRepository : IRepository<Buyers>
    {
        public readonly AppDbContext _context;
        public BuyersRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Buyers entity)
        {
            _context.Add(entity);
            var entriesDb = await _context.SaveChangesAsync();
            return entriesDb > 0;
        }

        public async Task<bool> Delete(Buyers entity)
        {
            _context.Remove(entity);
            var entriesDb = await _context.SaveChangesAsync();
            return entriesDb > 0;
        }

        public async Task<IEnumerable<Buyers>> Get()
        {
            IQueryable<Buyers> query = _context.Buyers;
            query = query.Include(p => p.Name)
                .Include(p => p.Address)
                .Include(p => p.Phone)
                .Include(p => p.Emails);

            return await query.ToListAsync();
        }

        public async Task<Buyers?> GetOne(string Id)
        {
            IQueryable<Buyers> query = _context.Buyers;
            query = query.Include(p => p.Name)
                .Include(p => p.Address)
                .Include(p => p.Phone)
                .Include(p => p.Emails);

            return await query.FirstOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<bool> Update(Buyers entity)
        {
            _context.Update(entity);
            var entriesDb = await _context.SaveChangesAsync();
            return entriesDb > 0;
        }
    }
}
