using AutoMapper;
using AddressApi.DAL.Entities;
using AddressApi.DAL.Interfaces;
using AddressApi.DAL.Repositories.Interfaces;
using SharedLibrary.DTO;

namespace AddressApi.DAL
{
    public class AddressDAL : IAddressDAL
    {
        private readonly IAddressRepository _repository;
        private readonly IMapper _mapper;

        public AddressDAL(IAddressRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AddressDto> GetByPostalCodeAsync(string postalCode)
        {
            var entity = await _repository.GetByPostalCodeAsync(postalCode);
            if (entity == null)
                return null;

            return _mapper.Map<AddressDto>(entity);
        }

        public async Task AddAsync(AddressDto address)
        {
            var entity = _mapper.Map<AddressEntity>(address);
            await _repository.AddAsync(entity);
        }
    }
}