using DJLNET.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.WebCore.Mvc
{
    public interface IAuthorizeProvider
    {
        void Login(User user, bool remember);

        void LoginOut();

        User GetAuthorizeUser();
    }
}
