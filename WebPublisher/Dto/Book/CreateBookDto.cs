using System.ComponentModel.DataAnnotations;

namespace WebPublisher.Dto.Book
{
    public class CreateBookDto
    {
        [Required(ErrorMessage ="Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Year is required")]
        [MaxLength(4,ErrorMessage ="Yers must be full year like '2024'")]
        public int Year { get; set; }
        [Required(ErrorMessage = "ISBN is required")]
        public string ISBN { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        [Range(1,double.MaxValue, ErrorMessage ="The minumum quantity is 1")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }
    }
}
