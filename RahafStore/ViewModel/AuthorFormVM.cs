using System.ComponentModel.DataAnnotations;

namespace RahafStore.ViewModel
{
    public class AuthorFormVM
    {
        public int Id { get; set; }
        [MaxLength(30,ErrorMessage ="Author Name must be At Most 30 Char")]
        public string Name { get; set; } = null!;
    
    }
}
