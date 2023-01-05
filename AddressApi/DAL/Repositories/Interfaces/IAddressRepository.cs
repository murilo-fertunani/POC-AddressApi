using AddressApi.DAL.Entities;

namespace AddressApi.DAL.Repositories.Interfaces
{
    public interface IAddressRepository
    {
        Task<AddressEntity> GetByPostalCodeAsync(string postalCode);
        Task AddAsync(AddressEntity entity);
    }
}