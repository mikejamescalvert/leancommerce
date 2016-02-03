using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.OptionsModel;
using LeanCommerce.Models;
using Microsoft.AspNet.Mvc.Filters;
using Microsoft.AspNet.Routing;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LeanCommerce.Abstract.Controllers
{
    public abstract class AbstractSetupRequiredController : Controller
    {
        private AppSettings _settings;
        public AbstractSetupRequiredController(IOptions<AppSettings> options) : base()
        {
            _settings = options.Value;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if ((string)context.RouteData.Values["controller"] != "setup")
            {
                if (_settings == null || _settings.SetupRequired() == true)
                    context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                        {{"controller", "Setup"}, {"action", "Welcome"}});
            }


            base.OnActionExecuting(context);
        }

    }
}
