using GameZone.Models;
using GameZone.ViewModels;

namespace GameZone.Services.Interfaces
{
    public interface IGamesService
    {
        public Task<IQueryable<Game>> GetAllAsync();
        public Task CreateAsync(CreateGameFormViewModel model);
        public Task<Game?> GetByIdAsync(int id);
    }
}
