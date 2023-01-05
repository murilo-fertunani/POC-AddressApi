using SharedLibrary.DTO;

namespace AddressApi.DAL.Interfaces
{
    public interface IAddressDAL
    {
        Task<AddressDto> GetByPostalCodeAsync(string postalCode);
        Task AddAsync(AddressDto address);
    }
}