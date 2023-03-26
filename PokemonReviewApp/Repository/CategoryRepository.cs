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
        public bool CategoryExists(int id)
        {
           return _context.Categories.Any(e => e.Id == id);
        }

        public bool CreateCategory(Category category)
        {
            // change Tracker
            // add, updating, modifying,
            // connected vs disconnected
            // EntityState.Added when you see this the its a disconnected state but its very uncommon
            _context.Add(category);
            //_context.SaveChanges(); // this could also work instaed of a seperate save method
            return Save();
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.OrderBy(e => e.Id).ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            return _context.PokemonCategories.Where(e => e.CategoryId == categoryId).Select(c => c.Pokemon).ToList();
            // this allow the icollection property to not return null in a one to may table 
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            // now when you call save changes that when the actual sql is generated qand sent to the database 
            return saved > 0 ?  true: false;
        }

        public bool UpdateCategory(Category category)
        {
            _context.Update(category);
            return Save();
        }
    }
}
