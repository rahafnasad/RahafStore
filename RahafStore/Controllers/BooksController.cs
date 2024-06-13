using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RahafStore.Data;
using RahafStore.Models;
using RahafStore.ViewModel;

namespace RahafStore.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment iWebHostEnv;

        public BooksController(ApplicationDbContext context , IWebHostEnvironment iWebHostEnv) {
            this.context = context;
            this.iWebHostEnv = iWebHostEnv;
        }
        public IActionResult Index()
        {
            var Book = context.Books.Include(book => book.Author)
                .Include(book => book.Categories)
                .ThenInclude(book => book.Category).ToList();
            var BookVM = Book.Select(book => new BookVM
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Publisher = book.Publisher,
                publisherDate = book.publisherDate,
                ImageURL = book.ImageURL,
                Categories = book.Categories.Select(book => book.Category.Name).ToList(),
            }).ToList();
      
            return View(BookVM);
        }
        [HttpGet]
        public IActionResult Create() {
            var authors = context.Authors.OrderBy(author=> author.Name).ToList();
            var categories = context.Categories.OrderBy(cat => cat.Name).ToList();

            var authorList = new List<SelectListItem>();
            foreach (var author in authors) {
                authorList.Add(new SelectListItem
                {
                    Value = author.Id.ToString(),
                    Text = author.Name


                });
            }


            var categoryList = new List<SelectListItem>();
            foreach (var category in categories)
            {
                categoryList.Add(new SelectListItem
                {
                    Value = category.Id.ToString(),
                    Text = category.Name


                });
            }
            var AuthorsVM = new BookFormVM
            {
                Authors = authorList,
                Categories= categoryList
            };


            return View(AuthorsVM);
        }
        [HttpPost]
        public IActionResult Create(BookFormVM BookVM) {
           
            if (!ModelState.IsValid) {
                return View(BookVM);
            }
            string ImageName = null;
         


            if (BookVM.ImageURL != null) {
                ImageName = Path.GetFileName(BookVM.ImageURL.FileName);

                var path = Path.Combine($"{iWebHostEnv.WebRootPath}/img/Book",ImageName);
                var stream = System.IO.File.Create(path);
                BookVM.ImageURL.CopyTo(stream);
            }
            var Book = new Book
            {
                Title = BookVM.Title,
                Publisher = BookVM.Publisher,
                publisherDate = BookVM.publisherDate,
                description = BookVM.description,
                AuthorId = BookVM.AuthorId,
                ImageURL = ImageName,

                Categories = BookVM.CategorisId.Select(Id => new BookCategory
                {
                    CategoryId = Id,
                }).ToList(),

            };
            context.Books.Add(Book);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
