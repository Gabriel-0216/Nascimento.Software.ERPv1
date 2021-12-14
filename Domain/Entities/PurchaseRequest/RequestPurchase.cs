using Domain.Entities.Buyer;
using Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.PurchaseRequest
{
    public class RequestPurchase 
    {
        public RequestPurchase()
        {
            Products = new List<Products>();
        }
        public bool SetBuyer(Buyers buyer)
        {
            //check if buyer exists
            if (buyer == null) return false;

            this.BuyerId = buyer.Id;
            return true;
        }
        public bool AddProductChart(List<Products> product)
        {
            Products = product;
            return true;
        }
        public bool FinishPurchaseRequest()
        {
            if(Products.Count == 0) return false;

            foreach(var item in Products)
            {
                PurchaseValue += item.ProductValue;
            }
            return true;
        }
        public string Id { get; private set; } = Guid.NewGuid().ToString();
        public string BuyerId { get; set; }
        public Buyers Buyer { get; set; }
        public ICollection<Products> Products { get; set; }
        public decimal PurchaseValue { get; set; }
        public DateTime Created_At { get; private set; } = DateTime.Now;
        public DateTime Updated_At { get; private set; } = DateTime.Now;

    }

}
