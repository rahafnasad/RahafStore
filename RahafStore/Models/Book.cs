using System.ComponentModel.DataAnnotations;

namespace RahafStore.Models
{
    public class Book
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; } = null!;
        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;
        public string Publisher { get; set; } = null!;
        public string description { get; set; } = null!;

        public DateTime publisherDate { get; set; }
        public string? ImageURL { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        public List<BookCategory> Categories { get; set; } = new List<BookCategory>();

    }
}
