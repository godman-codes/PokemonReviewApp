using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int id);
        Country GetCountryByOwner(int ownerId);
        ICollection<Owner> GetOwnersfromACountry(int countryId);
        bool CountryExists(int Id);

        bool CreateCountry(Country country);
        bool Save();

        bool UpdateCountry(Country country);
        bool DeleteCountry(Country country);
    }
}
