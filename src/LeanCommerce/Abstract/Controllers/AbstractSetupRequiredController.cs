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
        private Services.MongoSettings.Service.IMongoSettingsService _mongoService;
        public AbstractSetupRequiredController(Services.MongoSettings.Service.IMongoSettingsService mongoService) : base()
        {
            _mongoService = mongoService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if ((string)context.RouteData.Values["controller"] != "setup")
            {
                if (_mongoService == null || _mongoService.RequiresSetup() == true)
                    context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                        {{"controller", "Setup"}, {"action", "Welcome"}});
            }


            base.OnActionExecuting(context);
        }

    }
}
