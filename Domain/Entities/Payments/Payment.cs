using Domain.Entities.Buyer;
using Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Payments
{
    public abstract class Payment : Entity
    {
        public bool SetBuyer(Buyers buyer)
        {
            if (buyer == null) return false;

            BuyerId = buyer.Id;
            return true;
        }
        public bool SetPaymentAddress(Address address)
        {
            if(address == null) return false;

            PaymentAddress = address;
            return true;
        }
        public bool SetTotalPaid(decimal totalPaid)
        {
            if (totalPaid == 0) return false;
            return true;
        }
        public decimal TotalPaid { get; set; }
        public string BuyerId { get; set; }
        public Buyers Buyer { get; set; }
        public Address PaymentAddress { get; set; }
    }
}
