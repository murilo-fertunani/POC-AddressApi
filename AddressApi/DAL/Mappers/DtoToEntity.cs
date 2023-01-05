using AutoMapper;
using AddressApi.DAL.Entities;
using SharedLibrary.DTO;

namespace AddressApi.DAL.Mappers
{
    public class DtoToEntity : Profile
    {
        public DtoToEntity()
        {
            CreateMap<AddressDto, AddressEntity>();
        }
    }
}