using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Payments
{
    public class BoletoPayment : Payment
    {
        public string BarCode { get; set; }
        public string Bank { get; set; }
        public string Number { get; set; }


    }
}
