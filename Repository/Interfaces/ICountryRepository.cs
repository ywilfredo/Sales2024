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

        //Metodos asincronos

        Task<IEnumerable<Country>> AllCountriesAsync();
        Task<Country> GetByIdAsync(int id);
        Task<Country> CreateAsync(Country country);
        Task<Country> UpdateAsync(Country country);
        Task<Country> DeleteAsync(Country country);

    }
}
