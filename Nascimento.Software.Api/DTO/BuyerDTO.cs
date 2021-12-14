namespace Nascimento.Software.Api.DTO
{
    public class BuyerDTO
    {
        public NameDTO Name { get;  set; }
        public List<PhoneNumberDTO>? Phone { get;  set; }
        public AddressDTO? Address { get;  set; }
        public List<EmailDTO>? Emails { get;  set; }
    }
}
