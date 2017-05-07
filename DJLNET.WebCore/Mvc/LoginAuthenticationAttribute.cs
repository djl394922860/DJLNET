using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc.Filters;

namespace DJLNET.WebCore.Mvc
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class LoginAuthenticationAttribute : System.Web.Mvc.ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (filterContext == null)
                throw new ArgumentNullException(nameof(filterContext));
            var loginSkip = filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(System.Web.Mvc.AllowAnonymousAttribute), true);
            loginSkip = loginSkip || filterContext.ActionDescriptor.IsDefined(typeof(System.Web.Mvc.AllowAnonymousAttribute), true);
            if (loginSkip)
                return;

            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new System.Web.Mvc.RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new
                {
                    controller = "Home",
                    action = "Login"
                }));
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {

        }
    }
}
