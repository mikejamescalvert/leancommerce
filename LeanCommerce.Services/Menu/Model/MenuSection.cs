using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeanCommerce.Services.Menu.Model
{
    public class MenuSection
    {

        public MenuSection()
        {
            Children = new List<MenuItem>();
        }

        public int DisplayOrder { get; set; }
        public string Caption { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Icon { get; set; }
        public string RightLabel { get; set; }

        public IList<MenuItem> Children { get; set; }

    }
}
