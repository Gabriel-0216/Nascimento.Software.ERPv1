namespace Nascimento.Software.Api.DTO
{
    public class PurchaseDTO
    {
        public string BuyerId { get; set; }
        public List<ProductPurchaseDTO> Products { get; set; }

    }
}
