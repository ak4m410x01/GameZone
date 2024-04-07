using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Services.Interfaces
{
    public interface ICategoriesService
    {
        IEnumerable<SelectListItem> GetSelectListItems();
    }
}
