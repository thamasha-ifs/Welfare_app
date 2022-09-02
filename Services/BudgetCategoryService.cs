using System.Reflection.Metadata.Ecma335;
using Welfare_App.Context;
using Welfare_App.Entity;

namespace Welfare_App.Services
{
    public class BudgetCategoryService
    {
        private DataContext _context;   
        public BudgetCategoryService(DataContext context){
            _context = context;
        }

    
        public async Task<List<BudgetCategories>> GetAll() {
            return await _context.BudgetCategories.ToListAsync();  
        }

        public async Task<BudgetCategories> GetBudgetCategory(int id)
        {
            return await _context.BudgetCategories.FindAsync(id);
        }
        public void AddCategory(BudgetCategories category)
        {
            _context.BudgetCategories.Add(category);
            _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateCategory(int id,BudgetCategories category)
        {
            var existingCategory = await GetBudgetCategory(id);
            if (category != null && existingCategory != null)
            {
                existingCategory.Active = category.Active;
                existingCategory.CategoryName = category.CategoryName;
                _context.BudgetCategories.Update(existingCategory);
                _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> RemoveCategory(int id)
        {
            var category = await GetBudgetCategory(id);
            if (category != null)
            {
                _context.BudgetCategories.Remove(category);
                _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
