namespace WebPublisher.Data
{
    public class BookAuthor : Auditability
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Surname { get; set; }
        public string Specialization { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
    }
}
