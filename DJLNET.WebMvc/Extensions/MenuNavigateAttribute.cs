using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJLNET.WebMvc.Extensions
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class MenuNavigateAttribute : System.Attribute
    {
    }
}