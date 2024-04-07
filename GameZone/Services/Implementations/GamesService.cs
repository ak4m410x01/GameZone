using GameZone.Data;
using GameZone.Models;
using GameZone.Services.Interfaces;
using GameZone.Settings;
using GameZone.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Services.Implementations
{
    public class GamesService : IGamesService
    {
        public GamesService(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _imagesPath = $"{_webHostEnvironment.WebRootPath}{FileSettings.GamesImagesPath}";
        }

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imagesPath;

        public async Task<IQueryable<Game>> GetAllAsync()
        {
            return await Task
                .FromResult(
                    _context.Games
                        .Include(g => g.Category)
                        .Include(g => g.Devices)
                        .ThenInclude(d => d.Device)
                        .AsQueryable());
        }
        public async Task CreateAsync(CreateGameFormViewModel model)
        {
            string coverName = $"{Guid.NewGuid()}_{model.Name}{Path.GetExtension(model.Cover.FileName)}";
            string path = Path.Combine(_imagesPath, coverName);

            using FileStream stream = File.Create(path);
            await model.Cover.CopyToAsync(stream);

            Game game = new Game()
            {
                Name = model.Name,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Cover = coverName,
                Devices = model.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList(),
            };

            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
        }
        public async Task<Game?> GetByIdAsync(int id)
        {
            return await _context.Games.FindAsync(id);
        }
    }
}
