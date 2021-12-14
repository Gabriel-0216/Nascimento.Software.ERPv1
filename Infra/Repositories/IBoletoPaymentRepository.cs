using Domain.Entities.Payments;
using Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class BoletoPaymentRepository : IRepository<BoletoPayment>
    {
        private readonly AppDbContext _context;
        public BoletoPaymentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(BoletoPayment entity)
        {
            _context.BoletoPayments.Add(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<bool> Delete(BoletoPayment entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BoletoPayment>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<BoletoPayment?> GetOne(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(BoletoPayment entity)
        {
            throw new NotImplementedException();
        }
    }
}
