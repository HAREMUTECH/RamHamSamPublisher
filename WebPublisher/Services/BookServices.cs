using Azure.Core;
using Microsoft.EntityFrameworkCore;
using WebPublisher.Data;
using WebPublisher.Dto;
using WebPublisher.Dto.Book;
using WebPublisher.Repository;

namespace WebPublisher.Services
{
    public class BookServices : IBookServices
    {
        private readonly IBookRepository _bookRepository;
        private readonly ApplicationDbContext _dbContext;

        public BookServices(IBookRepository bookRepository, ApplicationDbContext dbContext)
        {
            _bookRepository = bookRepository;
            _dbContext = dbContext;
        }

        public async Task<BaseResponse<bool>> CreateBook(CreateBookDto request)
        {

            try
            {
                var book = await _dbContext.Books.FirstOrDefaultAsync(x => x.Title.ToLower() == request.Title.ToLower());

                if (book != null)
                {
                    return new BaseResponse<bool> { Message = "Book already exist", IsSuccessful = false };
                }

                var newBook = new Book()
                {
                    Title = request.Title,
                    Description = request.Description,
                    ISBN = request.ISBN,
                    Price = request.Price,
                    Quantity = request.Quantity,
                    Year = request.Year
                };

                await _dbContext.Books.AddAsync(newBook);

                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    return new BaseResponse<bool> { Message = "Book created successfully", IsSuccessful = true, Data = true };
                }

                return new BaseResponse<bool> { Message = "Book Creation failed", IsSuccessful = false, Data = false };
            }
            catch (Exception ex)
            {

                return new BaseResponse<bool> { Message = $"Error :  {ex.Message}", IsSuccessful = false, Data = false };
            }

        }

        public async Task<BaseResponse<bool>> Delete(Guid id)
        {
            try
            {
                var book = await _bookRepository.GetBookAsync(id);

                if (book != null)
                {
                    _dbContext.Books.Remove(book);

                    if (await _dbContext.SaveChangesAsync() > 0)
                    {
                        return new BaseResponse<bool> { Message = "Book deleted successfully", IsSuccessful = true, Data = true };
                    }
                }

                return new BaseResponse<bool> { Message = "Book not found", IsSuccessful = false, Data = false };
            }
            catch (Exception ex)
            {

                return new BaseResponse<bool> { Message = $"Error :  {ex.Message}", IsSuccessful = false, Data = false };
            }
        }

        public async Task<BaseResponse<List<BookDto>>> GetAllBooks()
        {
            try
            {
                var books = await _bookRepository.GetAllBooksAsync();

                if (books.Count > 0)
                {
                    var data = books.Select(x => new BookDto
                    {
                        Title = x.Title,
                        Description = x.Description,
                        ISBN = x.ISBN,
                        Id = x.Id,
                        Price = x.Price,
                        Quantity = x.Quantity,
                        Year = x.Year
                    }).ToList();

                    return new BaseResponse<List<BookDto>> { Message = "Data retrieved successfuly", IsSuccessful = true, Data = data };
                }

                return new BaseResponse<List<BookDto>> { Message = "No record", IsSuccessful = false, Data = new List<BookDto>() };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<BookDto>> { Message = $"Error :  {ex.Message}", IsSuccessful = false, Data = new List<BookDto>() };
            }
        }

        public async Task<BaseResponse<BookDto>> GetBook(Guid id)
        {
            try
            {
                var book = await _bookRepository.GetBookAsync(id);

                if (book != null)
                {
                    var data = new BookDto
                    {
                        Title = book.Title,
                        Description = book.Description,
                        ISBN = book.ISBN,
                        Id = book.Id,
                        Price = book.Price,
                        Quantity = book.Quantity,
                        Year = book.Year
                    };

                    return new BaseResponse<BookDto> { Message = "Data retrieved successfully", IsSuccessful = true, Data = data };
                }

                return new BaseResponse<BookDto> { Message = "No record", IsSuccessful = false, Data = new BookDto() };
            }
            catch (Exception ex)
            {
                return new BaseResponse<BookDto> { Message = $"Error :  {ex.Message}", IsSuccessful = false, Data = new BookDto() };
            }
        }

        public async Task<BaseResponse<bool>> UpdateBook(Guid id, UpdateBookDto request)
        {

            try
            {
                var book = await _bookRepository.GetBookAsync(id);

                if (book != null)
                {

                    book.Title = request.Title;
                    book.Description = request.Description;
                    book.ISBN = request.ISBN;
                    book.Price = request.Price;
                    book.Quantity = request.Quantity;
                    book.Year = request.Year;

                    _dbContext.Books.Update(book);

                    if (await _dbContext.SaveChangesAsync() > 0)
                    {
                        return new BaseResponse<bool> { Message = "Book updated successfully", IsSuccessful = true, Data = true };
                    }
                }


                return new BaseResponse<bool> { Message = "Book not found", IsSuccessful = false, Data = false };
            }
            catch (Exception ex)
            {

                return new BaseResponse<bool> { Message = $"Error :  {ex.Message}", IsSuccessful = false, Data = false };
            }

        }
    }
}