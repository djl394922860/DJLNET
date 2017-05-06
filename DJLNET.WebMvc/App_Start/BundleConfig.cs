using System.Collections.Generic;
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

            // mvc-jquery相关插件
            bundles.Add(new ScriptBundle("~/bundles/jqueryvalidate").
                Include("~/Scripts/jquery.validate.js"
                , "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/jquery.unobtrusive-ajax.js").ForceOrdered());

            // ace基础样式表
            bundles.Add(new StyleBundle("~/bundles/css")
                .Include("~/Content/Ace/assets/css/bootstrap.min.css",
                         "~/Content/Ace/assets/css/font-awesome.min.css"));
            // ace相关样式表
            bundles.Add(new StyleBundle("~/bundles/acecss").Include(
                "~/Content/Ace/assets/css/ace.min.css",
                "~/Content/Ace/assets/css/ace-rtl.min.css",
                "~/Content/Ace/assets/css/ace-skins.min.css"));

            // ace js 集合库
            bundles.Add(new ScriptBundle("~/bundles/acejs").Include(
                "~/Content/Ace/assets/js/bootstrap.min.js",
                "~/Content/Ace/assets/js/typeahead-bs2.min.js",
                "~/Content/Ace/assets/js/jquery-ui-1.10.3.custom.min.js",
                "~/Content/Ace/assets/js/jquery.ui.touch-punch.min.js",
                "~/Content/Ace/assets/js/jquery.slimscroll.min.js",
                "~/Content/Ace/assets/js/jquery.easy-pie-chart.min.js",
                "~/Content/Ace/assets/js/jquery.sparkline.min.js",
                "~/Content/Ace/assets/js/flot/jquery.flot.min.js",
                "~/Content/Ace/assets/js/flot/jquery.flot.pie.min.js",
                "~/Content/Ace/assets/js/flot/jquery.flot.resize.min.js",
                "~/Content/Ace/assets/js/ace-elements.min.js",
                "~/Content/Ace/assets/js/ace.min.js"
               ).ForceOrdered());
        }


    }

    internal class AsIsBundleOrderer : IBundleOrderer
    {
        public virtual IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            return files;
        }
    }

    internal static class BundleExtensions
    {
        public static Bundle ForceOrdered(this Bundle sb)
        {
            sb.Orderer = new AsIsBundleOrderer();
            return sb;
        }
    }
}
