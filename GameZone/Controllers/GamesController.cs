using GameZone.Data;
using GameZone.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        public GamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        private readonly ApplicationDbContext _context;

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateGameFormViewModel viewModel = new CreateGameFormViewModel()
            {
                Categories = _context.Categories
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .OrderBy(c => c.Text)
                .ToList(),

                Devices = _context.Devices
                .Select(d => new SelectListItem()
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                })
                .OrderBy(d => d.Text)
                .ToList(),
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateGameFormViewModel viewModel)
        {
            return View();
        }
    }
}
