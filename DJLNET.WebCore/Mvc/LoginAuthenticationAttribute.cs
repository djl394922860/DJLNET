using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace DJLNET.WebCore.Mvc
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class LoginAuthenticationAttribute : System.Web.Mvc.ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (filterContext == null)
                throw new ArgumentNullException(nameof(filterContext));
            if (filterContext.HttpContext == null)
            {
                throw new ArgumentNullException(nameof(filterContext.HttpContext));
            }
            var loginSkip = filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true);
            loginSkip = loginSkip || filterContext.ActionDescriptor.IsDefined(typeof(System.Web.Mvc.AllowAnonymousAttribute), true);
            if (loginSkip)
                return;

            if (filterContext.HttpContext.User == null || filterContext.HttpContext.User.Identity == null || !filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest() || filterContext.HttpContext.Request.Headers["X-Requested-With"].Equals("XMLHttpRequest", StringComparison.CurrentCultureIgnoreCase))
                {
                    filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new
                    {
                        controller = "Home",
                        action = "Login",
                        returnUrl = filterContext.HttpContext.Request.RawUrl
                    }));
                }
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {

        }
    }
}
