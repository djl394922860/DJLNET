using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DJLNET.Model.Entities;
using System.Web;
using System.Web.Security;
using DJLNET.Core.Extension;
using DJLNET.ApplicationService.Interfaces;

namespace DJLNET.WebCore.Mvc
{
    public class AuthorizeProdiver : IAuthorizeProvider
    {
        private readonly IUserService _service;

        public AuthorizeProdiver(IUserService service)
        {
            this._service = service;
        }

        public User GetAuthorizeUser()
        {
            var httpCnotext = HttpContext.Current;
            if (httpCnotext == null || httpCnotext.Request == null || httpCnotext.Request.IsAuthenticated || httpCnotext.User == null)
            {
                return null;
            }
            var user = httpCnotext.User;
            if (user.Identity == null || !(user.Identity is FormsIdentity))
            {
                return null;
            }
            var identity = user.Identity as FormsIdentity;
            if (identity.IsAuthenticated) return null;
            var userId = identity.Ticket.UserData.ToInt();
            var result = _service.Get(userId);
            return result;
        }

        public void Login(User user, bool remember)
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.Name, DateTime.Now, DateTime.Now.AddDays(3), true, user.ID.ToString(), FormsAuthentication.FormsCookiePath);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket))
            {
                HttpOnly = true
            };
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public void LoginOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}
