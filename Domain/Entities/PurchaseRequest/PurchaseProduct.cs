using Domain.Entities.Product;
using Domain.Entities.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.PurchaseRequest
{
    public class PurchaseProduct
    {
        public string ProductId { get; set; }
        public Products Product { get; set; }
        public string PurchaseId { get; set; }
        public Purchase Purchase { get; set; }
    }
}
