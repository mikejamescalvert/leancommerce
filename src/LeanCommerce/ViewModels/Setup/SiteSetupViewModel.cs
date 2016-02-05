using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeanCommerce.ViewModels.Setup
{
    public class SiteSetupViewModel
    {
        [Required]
        [Display(Name ="Site Name")]
        public string SiteName { get; set; }

    }
}
