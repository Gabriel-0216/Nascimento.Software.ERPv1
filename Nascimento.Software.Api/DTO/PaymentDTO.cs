namespace Nascimento.Software.Api.DTO
{
    public abstract class PaymentDTO
    {
        public decimal TotalPaid { get; private set; }
        public string BuyerId { get; set; }
        public AddressDTO PaymentAddress { get; set; }
    }
}
