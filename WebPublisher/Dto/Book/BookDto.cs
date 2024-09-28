using System.ComponentModel.DataAnnotations.Schema;

namespace WebPublisher.Dto.Book
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string ISBN { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
