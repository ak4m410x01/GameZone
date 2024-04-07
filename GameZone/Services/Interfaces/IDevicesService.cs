using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Services.Interfaces
{
    public interface IDevicesService
    {
        IEnumerable<SelectListItem> GetSelectListItems();
    }
}
