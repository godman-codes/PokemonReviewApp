using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class PokemonRepository: IPokemonRepository
    {
        private readonly DataContext _context;
        public PokemonRepository(DataContext context) 
        {
            // get the database context
            _context = context;
        }
        public ICollection<Pokemon> GetPokemons()
        {

            return _context.Pokemon.OrderBy(p => p.Id).ToList();
            //return the pokemon by the id and as a list
        }

        Pokemon IPokemonRepository.GetPokemon(int id)
        {
            return _context.Pokemon.Where(p => p.Id == id).FirstOrDefault();
            //return the pokemon with the id specified
        }

        Pokemon IPokemonRepository.GetPokemon(string name)
        {
            return _context.Pokemon.Where(p => p.Name == name).FirstOrDefault();
        }

        decimal IPokemonRepository.GetPokemonRating(int pokeId)
        {
            var review = _context.Reviews.Where(p=> p.Pokemon.Id == pokeId);
            // get all reviews of that pokemon withe the specified id
            if (review.Count() <= 0)
            {
                return 0;
            }

            return ((decimal)review.Sum(r => r.Rating)/review.Count());
            // sum all the ratings of the reviews and devide it by the number of reviews #
            // convert to decimal

        }

        bool IPokemonRepository.PokemonExists(int pokeId)
        {
            return _context.Pokemon.Any(p => p.Id == pokeId);
        }
    }
}
