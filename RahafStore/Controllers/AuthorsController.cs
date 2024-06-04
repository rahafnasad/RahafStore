using Microsoft.AspNetCore.Mvc;
using RahafStore.Data;
using RahafStore.Models;
using RahafStore.ViewModel;

namespace RahafStore.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly ApplicationDbContext context;

        public AuthorsController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var Authors = context.Authors.ToList();
            var AuthorsVM = new List<AuthorVM>();
            foreach (var author in Authors) {
                var authorVM = new AuthorVM
                {
                    Id = author.Id,
                    Name = author.Name,
                    CreatedOn = author.CreatedOn,
                    UpdatedOn = author.UpdatedOn
                };
                AuthorsVM.Add(authorVM);
            }
            return View(AuthorsVM);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(AuthorFormVM AuthorVM)
        {

            if (!ModelState.IsValid)
            {
                return View("Create", AuthorVM);
            }
            var Author = new Author
            {
                Name = AuthorVM.Name
            };
            try
            {
                context.Authors.Add(Author);
                context.SaveChanges();
                return RedirectToAction("index");
            }
            catch
            {
                ModelState.AddModelError("Name", "Category Name Already exists");
                return View("Create", AuthorVM);

            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var author = context.Authors.Find(id);
            if (author is null) return NotFound();
            var authorVM = new AuthorFormVM
            {
                Id = id,
                Name = author.Name
            };
            return View("Create", authorVM);

        }
        [HttpPost]
        public IActionResult Edit(AuthorFormVM authorVM)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", authorVM);
            }
            if (authorVM is null) return NotFound();


            var author = context.Authors.Find(authorVM.Id);
            author.Name = authorVM.Name;
            author.UpdatedOn = DateTime.Now;
            context.SaveChanges();
            return RedirectToAction("index");

        }
        public IActionResult Delete(int id)
        {
            var author = context.Authors.Find(id);
            context.Authors.Remove(author);
            context.SaveChanges();

            return Ok();

        }
        public IActionResult Detalis(int id)
        {
            var author = context.Authors.Find(id);
            var authorVM = new AuthorVM
            {
                Id = id,
                Name = author.Name,
                CreatedOn = author.CreatedOn,
                UpdatedOn = author.UpdatedOn
            };
            return View(authorVM);

        }
    }
}
