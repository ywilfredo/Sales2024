using Microsoft.EntityFrameworkCore;
using Sales.Data;
using Sales.Models;
using Sales.Repository.Interfaces;

namespace Sales.Repository.Implementations
{
    public class CountryRepository : ICountryRepository
    {
        private readonly SalesDbContext _context;
        public CountryRepository(SalesDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Country> AllCountries => _context.Countries.ToList();

        public void Create(Country country)
        {
            _context.Countries.Add(country);
            _context.SaveChanges();
        }
        public Country? GetById(int id)
        {
            Country? country = _context.Countries
                .FirstOrDefault(c => c.Id == id);
            return country;
        }
        public void Update(Country country)
        {
            _context.Countries.Update(country);
            _context.SaveChanges();
        }

        public void Delete(Country country)
        {
            _context.Countries.Remove(country);
            _context.SaveChanges();
        }



        public async Task<IEnumerable<Country>> AllCountriesAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country> CreateAsync(Country country)
        {
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();
            return country;
        }
       
        public Task<Country> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Country> UpdateAsync(Country country)
        {
            throw new NotImplementedException();
        }
        public Task<Country> DeleteAsync(Country country)
        {
            throw new NotImplementedException();
        }
    }
}
