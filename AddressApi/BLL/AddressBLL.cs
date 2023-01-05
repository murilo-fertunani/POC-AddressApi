using AddressApi.BLL.Interfaces;
using AddressApi.BLL.Strategies.Interfaces;
using AddressApi.BLL.Enum;
using AddressApi.DAL.Interfaces;
using MassTransit;
using SharedLibrary.DTO;
using SharedLibrary.DTO.Interfaces;

namespace AddressApi.BLL
{
    public class AddressBLL : IAddressBLL
    {
        private readonly IAddressDAL _dal;
        private readonly IAddressStrategy _strategy;
        private readonly IConfiguration _configuration;
        private readonly IPublishEndpoint _broker;

        public AddressBLL(IAddressDAL dal, IAddressStrategy strategy, IConfiguration configuration, IPublishEndpoint broker)
        {
            _dal = dal;
            _strategy = strategy;
            _configuration = configuration;
            _broker = broker;
        }

        public async Task<AddressDto> GetAddressAsync(string postalCode)
        {
            var address = await _dal.GetByPostalCodeAsync(postalCode);
            if (address != null)
                return address;

            var api = _configuration.GetValue<ApiType>("AddressApi:DefaultAddressApi");
            var adapter = _strategy.GetAdapter(api);
            address = await adapter.GetAddressAsync(postalCode);

            await _dal.AddAsync(address);
            await _broker.Publish<IAddressDto>(address);

            return address;
        }
    }
}