using Domain.Entities.Purchases;
using Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Product
{
    public class Products : Entity
    {
        public bool SetProductName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName)) return false;

            ProductName = new Name(firstName, "");

            return true;
        }
        public bool SetProductValue(decimal value)
        {
            if (value <= 0) return false;

            ProductValue = value;
            return true;
        }
        public bool AddQuantityStock(int quantity)
        {
            if(quantity <= 0) return false;

            AvailableQuantity += quantity;
            return true;
        }
        public bool RemoveQuantityFromStock(int quantity)
        {
            if (quantity <= 0) return false;

            AvailableQuantity -= quantity;
            return true;
        }
        public Name ProductName { get; set; }
        public decimal ProductValue { get; set; }
        public int AvailableQuantity { get; set; }
        public virtual IEnumerable<Purchase> Purchases { get; set; }
    }
}
