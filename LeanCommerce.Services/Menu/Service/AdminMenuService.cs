using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeanCommerce.Services.Menu.Model;

namespace LeanCommerce.Services.Menu.Service
{
    public class AdminMenuService : MenuService,IAdminMenuService
    {
        public AdminMenuService() :base()
        {
            LoadAdminMenu();
        }
        void LoadAdminMenu()
        {
            MenuSection section;
            MenuItem item;
            section = new MenuSection() { Action = "Index", Caption = "Dashboard", Controller = "Admin", DisplayOrder = 0, Icon = "fa-dashboard" };
            Sections.Add(section);
            section = new MenuSection() { Caption = "Catalog", DisplayOrder = 1, Icon = "fa-book" };
            item = new MenuItem() { Action = "CategorySetup", Caption = "Categories", Controller = "Admin", DisplayOrder = 0 };
            section.Children.Add(item);
            Sections.Add(section);
            section = new MenuSection() { Caption = "Site Settings", DisplayOrder = 2, Icon = "fa-cogs" };
            item = new MenuItem() { Action = "SiteSettings", Caption = "General", Controller = "Admin", DisplayOrder = 0 };
            section.Children.Add(item);
            Sections.Add(section);
        }
    }
}
