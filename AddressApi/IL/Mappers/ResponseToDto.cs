using System.Text.RegularExpressions;
using AddressApi.IL.Responses;
using AutoMapper;
using SharedLibrary.DTO;

namespace AddressApi.IL.Mappers
{
    public class ResponseToDto : Profile
    {
        public ResponseToDto()
        {
            CreateMap<AddressResponse, AddressDto>()
               .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => RemoveNonNumberCharacteres(src.Cep)))
               .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Logradouro))
               .ForMember(dest => dest.Complement, opt => opt.MapFrom(src => src.Complemento))
               .ForMember(dest => dest.Neighborhood, opt => opt.MapFrom(src => src.Bairro))
               .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Localidade))
               .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Uf));
        }

        private static string RemoveNonNumberCharacteres(string text)
        {
            var reg = new Regex(@"[^\d]");

            return reg.Replace(text, string.Empty);
        }
    }
}