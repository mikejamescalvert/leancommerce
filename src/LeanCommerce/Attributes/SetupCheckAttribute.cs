using LeanCommerce.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Filters;
using Microsoft.AspNet.Routing;
using Microsoft.Extensions.OptionsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeanCommerce.Attributes
{
    public class SetupCheckAttribute : ActionFilterAttribute
    {
        AppSettings settings;
        public SetupCheckAttribute() : base()
        {
            //todo: read accessor
            IOptions<AppSettings> optionsAccessor = null;
            if (optionsAccessor == null)
                return;
            settings = optionsAccessor.Value;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
            if (settings.MongoURL == string.Empty && (string)filterContext.RouteData.Values["controller"] != "setup")
            {
                // redirect must happen OnActionExecuting (not OnActionExecuted)
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Setup", action = "Welcome" })
                );

                base.OnActionExecuting(filterContext);
            }
        }

    }
}
