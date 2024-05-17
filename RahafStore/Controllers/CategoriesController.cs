using Microsoft.AspNetCore.Mvc;
using RahafStore.Data;

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
    }
}
