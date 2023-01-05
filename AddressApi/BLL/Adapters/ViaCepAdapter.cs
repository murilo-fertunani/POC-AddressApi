using AutoMapper;
using AddressApi.BLL.Adapters.Interfaces;
using AddressApi.BLL.Enum;
using AddressApi.IL.Interfaces;
using SharedLibrary.DTO;

namespace AddressApi.BLL.Adapters
{
    public class ViaCepAdapter : IAddressAdapter
    {
        private readonly IViaCepIL _il;
        private readonly IMapper _mapper;

        public ViaCepAdapter(IViaCepIL il, IMapper mapper)
        {
            _il = il;
            _mapper = mapper;
        }

        public ApiType GetApiType()
        {
            return ApiType.ViaCep;
        }

        public async Task<AddressDto> GetAddressAsync(string postalCode)
        {
            var address = await _il.GetAddressAsync(postalCode);

            return _mapper.Map<AddressDto>(address);
        }
    }
}