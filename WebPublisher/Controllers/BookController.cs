using Microsoft.AspNetCore.Mvc;

namespace WebPublisher.Controllers
{

	[Route("publisher-book")]
	public class BookController : Controller
	{
		[HttpGet("all-books")]
		public IActionResult Books()
		{

			var books = new List<string>() { "Ogidan" , "Jesus In Aboru" };



			ViewData["name"] = "Abdulhamiid";
			ViewBag.listOfBooks = books;
			return View();
		}


		[HttpGet("book")]
		public IActionResult Book()
		{




			var books = new List<string>() { "Ogidan", "Jesus In Aboru" };



			ViewData["name"] = "Abdulhamiid";
			ViewBag.listOfBooks = books;
			return View();
		}


	}
}
