using System.Web;
using System.Web.Optimization;

namespace Rhythm
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/rhythm/jquery")
                .Include("~/Scripts/rhythm/jquery-3.1.0.min.js")
                .Include("~/Scripts/rhythm/jquery-1.11.2.min.js")
                .Include("~/Scripts/rhythm/jquery.ajaxchimp.min.js")
                .Include("~/Scripts/rhythm/jquery.appear.js")
                .Include("~/Scripts/rhythm/jquery.countTo.js")
                .Include("~/Scripts/rhythm/jquery.easing.1.3.js")
                .Include("~/Scripts/rhythm/jquery.fitvids.js")
                .Include("~/Scripts/rhythm/jquery.localScroll.min.js")
                .Include("~/Scripts/rhythm/jquery.magnific-popup.min.js")
                .Include("~/Scripts/rhythm/jquery.parallax-1.1.3.js")
                .Include("~/Scripts/rhythm/jquery.scrollTo.min.js")
                .Include("~/Scripts/rhythm/jquery.simple-text-rotator.min.js")
                .Include("~/Scripts/rhythm/jquery.sticky.js")
                .Include("~/Scripts/rhythm/jquery.viewport.mini.js"));



            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                .Include("~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/rhythm/allJS")
                            .Include("~/Scripts/rhythm/imagesloaded.pkgd.min.js")
                            .Include("~/Scripts/rhythm/isotope.pkgd.min.js")
                            .Include("~/Scripts/rhythm/masonry.pkgd.min.js")
                            .Include("~/Scripts/rhythm/owl.carousel.min.js")
                            .Include("~/Scripts/rhythm/SmoothScroll.js")
                            .Include("~/Scripts/rhythm/wow.min.js")
                            .Include("~/Scripts/rhythm/placeholder.js")
                            .Include("~/Scripts/rhythm/all.js")
                            .Include("~/Scripts/rhythm/bootstrap.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/rhythm/jqueryval").Include(
                "~/Scripts/jquery.validate*",
                "~/Scripts/jquery.unobtrusive*"));



            bundles.Add(new StyleBundle("~/Content/Style")
                .Include("~/Content/css/bootstrap.min.css",
                "~/Content/css/style.css",
                "~/Content/css/style-responsive.css",
                "~/Content/css/animate.min.css",
                "~/Content/css/vertical-rhythm.min.css",
                "~/Content/css/owl.carousel.css",
                "~/Content/css/magnific-popup.css",
                "~/Content/css/et-line.css",
                "~/Content/css/font-awesome.min.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}