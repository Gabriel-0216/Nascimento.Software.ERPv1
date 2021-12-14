namespace Nascimento.Software.Api.DTO.Responses
{
    public class BoletoPaymentResponse
    {
        public BuyerDTO Buyer { get; set; }
        public string BoletoBarCode { get; set; } = Guid.NewGuid().ToString();
        public string Date { get; set; } = DateTime.Now.ToString("dd-MM-yyyy");
    }
}
