using LeanCommerce.Services.Menu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeanCommerce.Services.Menu.Service
{
    public interface IMenuService
    {
        IList<MenuSection> Sections { get; set; }
        string MenuCodeName { get; set; }
    }
}
