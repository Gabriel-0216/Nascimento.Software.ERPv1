namespace Nascimento.Software.Api.DTO
{
    public class CreditCardPaymentDTO : PaymentDTO
    {
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
    }
    
}
