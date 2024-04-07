using GameZone.Data;
using GameZone.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Services.Implementations
{
    public class CategoriesService : ICategoriesService
    {
        public CategoriesService(ApplicationDbContext context)
        {
            _context = context;
        }

        private readonly ApplicationDbContext _context;

        public IEnumerable<SelectListItem> GetSelectListItems()
        {
            return _context.Categories
                        .Select(c => new SelectListItem()
                        {
                            Value = c.Id.ToString(),
                            Text = c.Name
                        })
                        .OrderBy(c => c.Text)
                        .AsNoTracking()
                        .ToList();
        }
    }
}
