using GameZone.Data;
using GameZone.Services.Interfaces;
using GameZone.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        public GamesController(ICategoriesService categoriesService,
                               IDevicesService devicesService,
                               IGamesService gamesService)
        {
            _categoriesService = categoriesService;
            _devicesService = devicesService;
            _gamesService = gamesService;
        }

        private readonly ICategoriesService _categoriesService;
        private readonly IDevicesService _devicesService;
        private readonly IGamesService _gamesService;

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateGameFormViewModel model = new CreateGameFormViewModel()
            {
                Categories = _categoriesService.GetSelectListItems(),
                Devices = _devicesService.GetSelectListItems(),
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesService.GetSelectListItems();
                model.Devices = _devicesService.GetSelectListItems();

                return View(model);
            }
            // Save Model in Database

            await _gamesService.CreateAsync(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
