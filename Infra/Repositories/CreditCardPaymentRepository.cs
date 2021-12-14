using Domain.Entities.Payments;
using Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class CreditCardPaymentRepository : IRepository<CreditCartPayment>
    {
        private readonly AppDbContext _context;
        public CreditCardPaymentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(CreditCartPayment entity)
        {
            _context.Add(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<bool> Delete(CreditCartPayment entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CreditCartPayment>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<CreditCartPayment?> GetOne(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(CreditCartPayment entity)
        {
            throw new NotImplementedException();
        }
    }
}
