using Microsoft.AspNetCore.Mvc.Rendering;
using RahafStore.Models;
using System.ComponentModel.DataAnnotations;

namespace RahafStore.ViewModel
{
    public class BookFormVM
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; } = null!;
        [Display(Name ="Author")]
        public int AuthorId { get; set; }
        public List<SelectListItem> Authors { get; set; } = null!;
        public string Publisher { get; set; } = null!;
        [Display(Name = "publisher Date")]
        public DateTime publisherDate { get; set; } = DateTime.Now;
        [Display(Name = "Image")]

        public IFormFile? ImageURL { get; set; }
        public string description { get; set; } = null!;
        [Display(Name = "Categoris")]

        public List<int> CategorisId { get; set; } = new List<int>();
        public List<SelectListItem> Categories { get; set; }



    }
}
