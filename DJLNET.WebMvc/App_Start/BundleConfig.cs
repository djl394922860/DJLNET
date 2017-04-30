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

            // 基础样式表
            bundles.Add(new StyleBundle("~/bundles/css")
                .Include("~/Content/bootstrap.css",
                         "~/Content/font-awesome.css"));
            // ace相关样式表
            bundles.Add(new StyleBundle("~/bundles/acecss").Include(
                "~/Content/Ace/ace.min.css",
                "~/Content/Ace/ace-rtl.min.css",
                "~/Content/Ace/ace-skins.min.css"));

            // mvc-jquery相关插件
            bundles.Add(new ScriptBundle("~/bundles/jqueryvalidate").
                Include("~/Scripts/jquery.validate.js"
                , "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/jquery.unobtrusive-ajax.js"));

            // ace js 集合库
            bundles.Add(new ScriptBundle("~/bundles/acejs").Include(
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/Ace/typeahead-bs2.min.js",
                "~/Scripts/Ace/jquery-ui-1.10.3.custom.min.js",
                "~/Scripts/Ace/jquery.ui.touch-punch.min.js",
                "~/Scripts/Ace/jquery.slimscroll.min.js",
                "~/Scripts/Ace/jquery.easy-pie-chart.min.js",
                "~/Scripts/Ace/jquery.sparkline.min.js",
                "~/Scripts/Ace/jquery.flot.min.js",
                "~/Scripts/Ace/jquery.flot.pie.min.js",
                "~/Scripts/Ace/jquery.flot.resize.min.js",
                "~/Scripts/Ace/ace-elements.min.js",
                "~/Scripts/Ace/ace.min.js"
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
