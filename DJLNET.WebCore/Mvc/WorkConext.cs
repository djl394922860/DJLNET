using DJLNET.Core;
using DJLNET.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.WebCore.Mvc
{
    public static class WorkConext
    {
        public static User CurrentUser
        {
            get
            {
                var authPro = ServiceContainer.Resole<IAuthenticateProvider>();
                var user = authPro.GetAuthenticateUser();
                return user;
            }
        }
    }
}
