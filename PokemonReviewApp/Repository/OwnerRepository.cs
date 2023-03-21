using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _context;

        public OwnerRepository(DataContext context)
        {
            _context = context;
        }
        Owner IOwnerRepository.GetOwner(int ownerId)
        {
            return _context.Owners.Where(o => o.Id == ownerId).FirstOrDefault();
        }

        ICollection<Owner> IOwnerRepository.GetOwnerOfPokemon(int pokeId)
        {
            return _context.PokemonOwners.Where(p => p.Pokemon.Id == pokeId).Select(o => o.Owner).ToList();
            
        }

        ICollection<Owner> IOwnerRepository.GetOwners()
        {
            return _context.Owners.OrderBy(o => o.Id).ToList();
        }

        ICollection<Pokemon> IOwnerRepository.GetPokemonByOwner(int ownerId)
        {
            return _context.PokemonOwners.Where(o => o.OwnerId == ownerId).Select(p => p.Pokemon).ToList();
        }

        bool IOwnerRepository.OwnerExists(int ownerId)
        {
           return _context.Owners.Any(o => o.Id == ownerId);
        }
    }
}
