using AddressApi.BLL.Enum;
using SharedLibrary.DTO;

namespace AddressApi.BLL.Adapters.Interfaces
{
    public interface IAddressAdapter
    {
        ApiType GetApiType();
        Task<AddressDto> GetAddressAsync(string postalCode);
    }
}