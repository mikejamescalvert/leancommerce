using LeanCommerce.Services.Menu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeanCommerce.Services.Menu.Service
{
    public abstract class MenuService : IMenuService
    {
        public string MenuCodeName { get; set; }
        public IList<MenuSection> Sections { get; set; }

        public MenuService()
        {
            Sections = new List<MenuSection>();
        }

    }
}
