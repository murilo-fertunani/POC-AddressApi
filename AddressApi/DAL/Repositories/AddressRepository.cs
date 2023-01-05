using Microsoft.EntityFrameworkCore;
using AddressApi.DAL.Contexts;
using AddressApi.DAL.Entities;
using AddressApi.DAL.Repositories.Interfaces;

namespace AddressApi.DAL.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _context;

        public AddressRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AddressEntity> GetByPostalCodeAsync(string postalCode)
        {
            return await _context.Addresses
                .FirstOrDefaultAsync(f => f.IsActive
                                          && f.PostalCode == postalCode);
        }

        public async Task AddAsync(AddressEntity entity)
        {
            await _context.Addresses.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}