using AutoMapper;
using Domain.Entities.Buyer;
using Domain.Entities.Product;
using Domain.Entities.PurchaseRequest;
using Domain.Value_Objects;
using Nascimento.Software.Api.DTO;

namespace Nascimento.Software.Api.Helpers
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Buyers, BuyerDTO>().ReverseMap();
            CreateMap<PhoneNumber, PhoneNumberDTO>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<EmailDTO, Email>().ReverseMap();
            CreateMap<Name, NameDTO>().ReverseMap();


        }
    }
}
