using DJLNET.Core;
using DJLNET.WebCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DJLNET.WebCore.Security
{
    [AttributeUsage(validOn: AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ActionAuthorizationAttribute : AuthorizeAttribute
    {
        private readonly IAuthorizeProvider auth;

        public string[] PermissionNames { get; private set; }

        public ActionAuthorizationAttribute(params string[] permissionNames)
        {
            this.PermissionNames = permissionNames ?? new string[] { };
            auth = ServiceContainer.Resole<IAuthorizeProvider>();
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
                throw new ArgumentNullException(nameof(filterContext));
            var skip = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true);
            skip = skip || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true);
            if (skip)
                return;

            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                this.HandleUnauthorizedRequest(filterContext);
                return;
            }

            var action = filterContext.ActionDescriptor.ActionName;
            var controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var checkPermissionNames = this.PermissionNames.ToList();
            checkPermissionNames.Add(controller + action);
            checkPermissionNames = checkPermissionNames.Distinct(EqualityComparer<string>.Default).ToList();

            if (checkPermissionNames.Any(x => auth.Authorize(x)))
            {
                return;
            }

            this.HandleUnauthorizedRequest(filterContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Forbidden, "HandleUnauthorized Error");
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}
