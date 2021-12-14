using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Product
{
    public class ProductStock : Entity
    {
        public bool SetProductId(string Id)
        {
            if (string.IsNullOrWhiteSpace(Id)) return false;

            ProductId = Id;
            return true;
        }
        public bool SetQuantity(int Quantity)
        {
            if (Quantity <= 0) return false;

            quantityAdded = Quantity;
            return true;
        }
        public string ProductId { get; set; }
        public Products Product { get; set; }
        public int quantityAdded { get; set; }
    }
}
