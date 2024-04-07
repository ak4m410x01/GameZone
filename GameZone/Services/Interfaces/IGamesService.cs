using GameZone.ViewModels;

namespace GameZone.Services.Interfaces
{
    public interface IGamesService
    {
        public Task CreateAsync(CreateGameFormViewModel model);
    }
}
