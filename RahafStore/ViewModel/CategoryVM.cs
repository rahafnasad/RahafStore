using System.ComponentModel.DataAnnotations;

namespace RahafStore.ViewModel
{
    public class CategoryVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Category Name Is required")]
        [MaxLength(30,ErrorMessage ="Category Name Must Be Less Than 30 Char")]
        public string Name { get; set; } = null!;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
}
