using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        bool ICategoryRepository.CategoryExists(int id)
        {
           return _context.Categories.Any(e => e.Id == id);
        }

        ICollection<Category> ICategoryRepository.GetCategories()
        {
            return _context.Categories.OrderBy(e => e.Id).ToList();
        }

        Category ICategoryRepository.GetCategory(int id)
        {
            return _context.Categories.Where(e => e.Id == id).FirstOrDefault();
        }

        ICollection<Pokemon> ICategoryRepository.GetPokemonByCategory(int categoryId)
        {
            return _context.PokemonCategories.Where(e => e.CategoryId == categoryId).Select(c => c.Pokemon).ToList();
            // this allow the icollection property to not return null in a one to may table 
        }
    }
}
