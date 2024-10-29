using Sales.Data;
using Sales.Models;
using Sales.Repository.Interfaces;

namespace Sales.Repository.Implementations
{
    public class CountryRepository : ICountryRepository
    {
        private readonly SalesDbContext _context;
        public CountryRepository( SalesDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Country> AllCountries => _context.Countries.ToList();

        public void Create(Country country)
        {
            try
            {
                _context.Countries.Add(country);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(Country country)
        {
            try
            {
                _context.Countries.Remove(country);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Country? GetById(int id)
        {
            Country? country = _context.Countries
                .FirstOrDefault(c => c.Id == id);
            return country;
        }

        public void Update(Country country)
        {
            try
            {
                _context.Countries.Update(country);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
