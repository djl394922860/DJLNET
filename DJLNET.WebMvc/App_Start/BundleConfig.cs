using System.Web;
using System.Web.Optimization;

namespace DJLNET.WebMvc
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // 是否启用cdn加速
            bundles.UseCdn = false;
            // 是有启用压缩
            BundleTable.EnableOptimizations = false;

        }
    }
}
