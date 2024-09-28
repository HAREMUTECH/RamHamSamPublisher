using WebPublisher.Data;

namespace WebPublisher.Repository
{
    public interface IBookRepository
    {
        Task<Book> GetBookAsync(Guid id);
        Task<List<Book>> GetAllBooksAsync();
        Task<Book?> GetBookByTitleAsync(string title);

	}
}
