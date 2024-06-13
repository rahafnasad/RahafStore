using RahafStore.Models;
using System.ComponentModel.DataAnnotations;

namespace RahafStore.ViewModel
{
    public class BookVM
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public Author Author { get; set; } = null!;
        public string Publisher { get; set; } = null!;

        public DateTime publisherDate { get; set; }
        public string? ImageURL { get; set; }
        public List<string> Categories { get; set; }
    }
}
