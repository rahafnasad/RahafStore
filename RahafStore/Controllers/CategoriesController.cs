using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RahafStore.Data;
using RahafStore.Models;
using RahafStore.ViewModel;

namespace RahafStore.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext context;

        public CategoriesController(ApplicationDbContext context) {
            this.context = context;
        }
        public IActionResult Index()
        {
            var Result = context.Categories.ToList();
            return View(Result);
        }
        [HttpGet]
        public IActionResult Create() {

            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryVM category)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", category);
            }
                var newCategory = new Category{
                Name = category.Name
            };
            try
            {
                context.Categories.Add(newCategory);
                context.SaveChanges();
                return RedirectToAction("index");
            }
            catch {
                ModelState.AddModelError("Name", "Category Name Already exists");
                return View("Create", category);

            }
        }
        [HttpGet]
        public IActionResult Edit(int id) {

            var category = context.Categories.Find(id);
            if (category is null) return NotFound();
            var categoryVM = new CategoryVM
            {
                Id = id,
                Name = category.Name
            };
            return View("Create", categoryVM);
        
        }
        [HttpPost]
        public IActionResult Edit(CategoryVM category)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", category);
            }
            if (category is null) return NotFound();

           
            var newCategory = context.Categories.Find(category.Id);
            newCategory.Name = category.Name;
            newCategory.UpdatedOn = DateTime.Now;
            context.SaveChanges();
            return RedirectToAction("index");

        }
        public IActionResult Delete(int id) {
            var category = context.Categories.Find(id);
            context.Categories.Remove(category);
            context.SaveChanges();

            return Ok();

        }
        public IActionResult Detalis(int id) {
            var category = context.Categories.Find(id);
            var categoryVM = new CategoryVM
            {
                Id = id,
                Name = category.Name,
                CreatedOn = category.CreatedOn,
                UpdatedOn = category.UpdatedOn
            };
            return View(categoryVM);

        }
    }
}
