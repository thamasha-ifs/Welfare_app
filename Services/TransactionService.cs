using Welfare_App.Context;
using Welfare_App.Entity;

namespace Welfare_App.Services
{
    public class TransactionService
    {
        DataContext _context;
        public TransactionService(DataContext context)
        {
            _context = context;
        }
        public List<Transactions> GetTransactions()
        {
            return _context.Transactions.ToList();
        }
        public Transactions GetTransaction(int TransactionID)
        {
            return _context.Transactions.Find(TransactionID);
        }
        public void AddTransactions(Transactions transactions)
        {
            _context.Transactions.Add(transactions);
            _context.SaveChanges();
        }
    }
}
