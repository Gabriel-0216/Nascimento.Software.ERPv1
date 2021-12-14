using Domain.Entities.Buyer;
using Domain.Entities.PurchaseRequest;
using Domain.Entities.Payments;
using Domain.Entities.Product;

namespace Domain.Entities.Purchases
{
    public class Purchase : Entity
    {
        public Purchase()
        {
            Products = new List<Products>();
        }
        public bool SetPayment(Payment payment)
        {
            if (payment == null) return false;
            if (payment.TotalPaid == 0 || payment.TotalPaid < PurchaseTotalValue || payment.TotalPaid > PurchaseTotalValue) return false;

            Payments = payment;
            return true;
        }
        public bool SetBuyer(Buyers buyer)
        {
            if (buyer == null) return false;
            Buyer = buyer;
            BuyerId = buyer.Id;
            return true;
        }
       
        public bool FinishPurchase()
        {
            if (Payments == null) return false;
            if (Buyer == null) return false;

            return true;
        }
        public bool AddProductList(List<Products> products)
        {
            if (products.Count == 0) return false;
            Products = products;
            return true;
        }

        public string BuyerId { get; set; }
        public Buyers Buyer { get; set; }
        public decimal PurchaseTotalValue { get; set; }
        public virtual IEnumerable<Products> Products { get; set; }
        public string PaymentId { get; set; }
        public Payment Payments { get; set; }

    }
}
