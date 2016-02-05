using LeanCommerce.Services.Menu.Service;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeanCommerce.ViewComponents
{
    public class AdminMenuViewComponent : ViewComponent
    {
        private IAdminMenuService _adminMenuService;
        public AdminMenuViewComponent(IAdminMenuService adminMenuService)
        {
            _adminMenuService = adminMenuService;
        }

        public IViewComponentResult Invoke(int maxPriority)
        {
            var items = _adminMenuService.Sections.OrderBy(x => x.DisplayOrder);

            return View(items);
        }

    }
}
