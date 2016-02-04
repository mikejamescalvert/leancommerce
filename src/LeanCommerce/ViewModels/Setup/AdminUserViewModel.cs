using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeanCommerce.ViewModels.Setup
{
    public class AdminUserViewModel
    {
        private string _EmailAddress;
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name="Email Address")]
        public string EmailAddress
        {
            get { return _EmailAddress; }
            set
            {
                _EmailAddress = value;
            }
        }
        private string _Password;
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
            }
        }
        private string _ConfirmPassword;
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password Confirmation")]
        public string ConfirmPassword
        {
            get { return _ConfirmPassword; }
            set
            {
                _ConfirmPassword = value;
            }
        }
        
    }
}
