using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_LavApp.Filters
{
    public class Acceder:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var usuario = HttpContext.Current.Session["Usuario"];
            if (usuario == null)
            {
                filterContext.Result = new RedirectResult("~/login_/Index");
            }
            base.OnActionExecuted(filterContext);
        }
    }
}