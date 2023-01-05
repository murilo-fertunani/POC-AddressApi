using AddressApi.IL.Responses;

namespace AddressApi.IL.Clients.Interfaces
{
    public interface IViaCepClient
    {
        Task<AddressResponse> GetAddressAsync(string postalCode);
    }
}