using Microsoft.EntityFrameworkCore;
using WebPublisher.Data;

namespace WebPublisher.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BookRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _dbContext.Books.ToListAsync();

        }

        public async Task<Book?> GetBookAsync(Guid id)
        {
            return await _dbContext.Books.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}