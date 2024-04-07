using GameZone.Data;
using GameZone.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Services.Implementations
{
    public class DevicesService : IDevicesService
    {
        public DevicesService(ApplicationDbContext context)
        {
            _context = context;
        }

        private readonly ApplicationDbContext _context;

        public IEnumerable<SelectListItem> GetSelectListItems()
        {
            return _context.Devices
                        .Select(d => new SelectListItem()
                        {
                            Value = d.Id.ToString(),
                            Text = d.Name
                        })
                        .OrderBy(d => d.Text)
                        .AsNoTracking()
                        .ToList();
        }
    }
}
