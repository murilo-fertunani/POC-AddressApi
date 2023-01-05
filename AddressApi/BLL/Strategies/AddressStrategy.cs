using AddressApi.BLL.Adapters.Interfaces;
using AddressApi.BLL.Strategies.Interfaces;
using AddressApi.BLL.Enum;

namespace AddressApi.BLL.Strategies
{
    public class AddressStrategy : IAddressStrategy
    {
        private readonly IEnumerable<IAddressAdapter> _adapters;

        public AddressStrategy(IEnumerable<IAddressAdapter> adapters)
        {
            _adapters = adapters;
        }

        public IAddressAdapter GetAdapter(ApiType api)
        {
            var adapter = _adapters.FirstOrDefault(f => f.GetApiType().Equals(api));
            if (adapter == null)
                throw new Exception($"Serviço não configurado para utilização da API {api}");

            return adapter;
        }
    }
}