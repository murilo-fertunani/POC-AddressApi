using AddressApi.IL.Clients.Interfaces;
using AddressApi.IL.Interfaces;
using AutoMapper;
using SharedLibrary.DTO;

namespace AddressApi.IL
{
    public class ViaCepIL : IViaCepIL
    {
        private readonly IViaCepClient _client;
        private readonly IMapper _mapper;

        public ViaCepIL(IViaCepClient client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        public async Task<AddressDto> GetAddressAsync(string postalCode)
        {
            var address = await _client.GetAddressAsync(postalCode);

            return _mapper.Map<AddressDto>(address);
        }
    }
}