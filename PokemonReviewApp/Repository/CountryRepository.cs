using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;
        public CountryRepository(DataContext context)
        {
            _context = context;
        }
        bool ICountryRepository.CountryExists(int Id)
        {
            return _context.Countries.Any(c => c.Id == Id);
        }

        ICollection<Country> ICountryRepository.GetCountries()
        {
            return _context.Countries.OrderBy(c => c.Id).ToList();
        }

        Country ICountryRepository.GetCountry(int id)
        {
            return _context.Countries.Where(c => c.Id == id).FirstOrDefault();
        }

        Country ICountryRepository.GetCountryByOwner(int ownerId)
        {
            return _context.Owners.Where(o => o.Id == ownerId).Select(c => c.Country).FirstOrDefault();
        }

        ICollection<Owner> ICountryRepository.GetOwnersfromACountry(int countryId)
        {
            return _context.Owners.Where(c => c.Country.Id == countryId).ToList();
        }
    }
}
