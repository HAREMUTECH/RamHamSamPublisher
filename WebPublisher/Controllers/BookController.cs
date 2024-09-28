using Microsoft.AspNetCore.Mvc;
using WebPublisher.Dto.Book;
using WebPublisher.Services;

namespace WebPublisher.Controllers
{

	[Route("publisher-book")]
	public class BookController : Controller
	{
		private readonly IBookServices _bookServices;

		public BookController(IBookServices bookServices)
		{
			_bookServices = bookServices;
		}


		[HttpGet("all-books")]
		public async Task<IActionResult> BooksAsync()
		{
			var result = await _bookServices.GetAllBooks();
			return View(result.Data);
		}


		[HttpGet("book/{id}")]
		public async Task<IActionResult> BookDetailAsync([FromRoute] Guid id)
		{
			var result = await _bookServices.GetBook(id);
			return View(result.Data);
		}

		[HttpGet("create-book")]
		public async Task<IActionResult> CreateBook()
		{

			return View();
		}


		[HttpPost("create-book")]
		public async Task<IActionResult> CreateBookAsync([FromForm] CreateBookDto request)
		{
			var result = await _bookServices.CreateBook(request);
			if (result.IsSuccessful)
			{
				return RedirectToAction("Books");
			}
			return RedirectToAction("CreateBook");
		}

		[HttpGet("update-book/{id}")]
		public async Task<IActionResult> UpdateBook([FromRoute] Guid id)
		{
			var result = await _bookServices.GetBook(id);
			return View(result.Data);
		}

		[HttpPost("update-book/{id}")]
		public async Task<IActionResult> UpdateBookAsync([FromRoute] Guid id, [FromForm] UpdateBookDto request)
		{
			var result = await _bookServices.UpdateBook(id, request);

			if (result.IsSuccessful)
			{
				return RedirectToAction("BookDetail", new { id = id });
			}
			return RedirectToAction("Books");
		}


		[HttpGet("delete-book/{id}")]
		public async Task<IActionResult> DeleteBookAsync([FromRoute] Guid id)
		{
			var result = await _bookServices.Delete(id);
			if (result.IsSuccessful)
			{
				return RedirectToAction("Books");
			}
			return RedirectToAction("Books");
		}

	}
}
