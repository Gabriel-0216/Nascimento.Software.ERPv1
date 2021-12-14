using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Payments
{
    public class CreditCartPayment : Payment
    {
        public CreditCartPayment()
        {

        }
        public bool SetCreditCart(string cardHolderName, string cardNumber)
        {
            CardHolderName = cardHolderName;
            CardNumber = cardNumber;

            return true;
        }
        public string CardHolderName { get; private set; }
        public string CardNumber { get; private set; }
    }
}
