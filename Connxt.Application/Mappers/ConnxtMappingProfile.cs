using AutoMapper;
using Connxt.Application.Commands;
using Connxt.Application.Commands.Models;
using Connxt.Core.Entities;
using Newtonsoft.Json;

namespace Connxt.Application.Mappers
{
    public class ConnxtMappingProfile : Profile
    {
        public ConnxtMappingProfile()
        {
            CreateMap<CreditCardValidation, AddCreditCardCommand>().ReverseMap()
                .ForMember(dest => dest.CardValidationConfiguration, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.CreditCardPropertiesModel)));
           CreateMap<CreditCardProperty, CreditCardPropertyModel>().ReverseMap();
        }
    }
}