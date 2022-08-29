using Welfare_App.Context;
using Welfare_App.Entity;

namespace Welfare_App.Services
{
    public class DocumentService
    {
        DataContext _context;
        public DocumentService(DataContext context)
        {
            _context = context;
        }
        public List<Documents> GetDocuments()
        {
            return _context.Documents.ToList();
        }
        public Documents GetDocument(int docId)
        {
            return _context.Documents.Find(docId);
        }
        public void AddDocuments(Documents document)
        {
            _context.Documents.Add(document);
            _context.SaveChanges();
        }
        public void RemoveDocument(int docId)
        {
            var document = GetDocument(docId);
            if (document != null)
            {
                _context.Documents.Remove(document);
                _context.SaveChanges();

            }
        }
        public void EmailDocument(int docId)
        {
            var document = GetDocument(docId);
            //Email Document
        }
    }
}
