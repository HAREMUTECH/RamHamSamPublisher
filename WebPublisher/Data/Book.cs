using System.ComponentModel.DataAnnotations.Schema;

namespace WebPublisher.Data
{
    public class Book : Auditability
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string ISBN { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName ="Money")]
        public decimal Price { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; } = new HashSet<BookAuthor>();
    }
}
