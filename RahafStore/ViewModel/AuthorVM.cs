using System.ComponentModel.DataAnnotations;

namespace RahafStore.ViewModel
{
    public class AuthorVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
}
