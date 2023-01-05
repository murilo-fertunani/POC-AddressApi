using SharedLibrary.DTO;

namespace AddressApi.IL.Interfaces
{
    public interface IViaCepIL
    {
        Task<AddressDto> GetAddressAsync(string postalCode);
    }
}