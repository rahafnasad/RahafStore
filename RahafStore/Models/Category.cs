using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RahafStore.Models
{
    [Index(nameof(Name),IsUnique =true)]
    public class Category
    {
      

        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; } = null!;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        public List<BookCategory> Book { get; set; } = new List<BookCategory>();

    }
}
