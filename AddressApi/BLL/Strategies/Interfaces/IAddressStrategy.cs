using AddressApi.BLL.Adapters.Interfaces;
using AddressApi.BLL.Enum;

namespace AddressApi.BLL.Strategies.Interfaces
{
    public interface IAddressStrategy
    {
        IAddressAdapter GetAdapter(ApiType api);
    }
}