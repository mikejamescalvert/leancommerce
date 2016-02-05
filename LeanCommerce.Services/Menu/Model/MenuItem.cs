using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeanCommerce.Services.Menu.Model
{
    public class MenuItem
    {
        public int DisplayOrder { get; set; }
        public string Caption { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
    }
}
