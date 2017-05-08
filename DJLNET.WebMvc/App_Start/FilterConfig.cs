using DJLNET.WebCore.Mvc;
using DJLNET.WebCore.Security;
using System.Web;
using System.Web.Mvc;

namespace DJLNET.WebMvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LoginAuthenticationAttribute());
        }
    }
}
