using AutoMapper;
using AddressApi.DAL.Entities;
using SharedLibrary.DTO;

namespace AddressApi.DAL.Mappers
{
    public class EntityToDto : Profile
    {
        public EntityToDto()
        {
            CreateMap<AddressEntity, AddressDto>();
        }
    }
}