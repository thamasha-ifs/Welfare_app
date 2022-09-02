using Welfare_App.Context;
using Welfare_App.Entity;

namespace Welfare_App.Services
{
    public class BudgetCategoryItemService
    {
        private DataContext _context;
        public BudgetCategoryItemService(DataContext context) 
        {
            _context = context;
        }
        public async Task<List<BudgetCategoryItems>> GetAll()
        {
            return await _context.BudgetCategoryItems.ToListAsync();
        }

        public async Task<BudgetCategoryItems> GetBudgetCategoryItem(int id)
        {
            return await _context.BudgetCategoryItems.FindAsync(id);
        }

        public async Task<List<BudgetCategoryItems>> GetBudgetCategoryItemByTrip(int id)
        {
            return await _context.BudgetCategoryItems.Where(b => b.TripId == id).ToListAsync();
        }

        public async Task<List<BudgetCategoryItems>> GetBudgetCategoryItemByType(string category)
        {
            return await _context.BudgetCategoryItems.Where(b => b.BudgetItemType.Equals(category)).ToListAsync();
        }


        public void AddCategoryItem(BudgetCategoryItems categoryItem)
        {
            _context.BudgetCategoryItems.Add(categoryItem);
            _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateCategoryItem(int id, BudgetCategoryItems categoryItem)
        {
            var existingCategoryItem = await _context.BudgetCategoryItems.FindAsync(id);
            if (categoryItem != null && existingCategoryItem != null)
            {
                existingCategoryItem.Desciption = categoryItem.Desciption;
                existingCategoryItem.BudgetItemName = categoryItem.BudgetItemName;
                existingCategoryItem.TripId = categoryItem.TripId;
                existingCategoryItem.BudgetItemType = categoryItem.BudgetItemType;
                
                _context.BudgetCategoryItems.Update(existingCategoryItem);
                _context.SaveChangesAsync();
                return true;

            }
            return false;
        }
        public async Task<bool> RemoveCategoryItem(int id)
        {
            var categoryItem = await GetBudgetCategoryItem(id);
            if (categoryItem != null)
            {
                _context.BudgetCategoryItems.Remove(categoryItem);
                _context.SaveChangesAsync();
                return true;

            }
            return false;
        }
    }
}
