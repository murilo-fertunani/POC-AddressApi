using SharedLibrary.DTO;

namespace AddressApi.BLL.Interfaces
{
    public interface IAddressBLL
    {
        Task<AddressDto> GetAddressAsync(string postalCode);
    }
}