using WebPublisher.Dto;
using WebPublisher.Dto.Book;

namespace WebPublisher.Services
{
    public interface IBookServices
    {
        Task<BaseResponse<bool>> CreateBook(CreateBookDto request);
        Task<BaseResponse<bool>> UpdateBook(Guid id, UpdateBookDto request);
        Task<BaseResponse<BookDto>> GetBook(Guid id);
        Task<BaseResponse<bool>> Delete(Guid id);
        Task<BaseResponse<List<BookDto>>> GetAllBooks();
    }
}
