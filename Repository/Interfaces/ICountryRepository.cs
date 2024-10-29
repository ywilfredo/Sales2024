using Sales.Models;

namespace Sales.Repository.Interfaces
{
    public interface ICountryRepository
    {
        IEnumerable<Country> AllCountries { get; }
        Country? GetById(int id);

        void Create(Country country);

        void Update(Country country);

        void Delete(Country country);
    }
}
