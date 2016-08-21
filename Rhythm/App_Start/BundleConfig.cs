using System.Web;
using System.Web.Optimization;

namespace Rhythm
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/rhythm/jquery")
                .Include("~/scripts/rhythm/jquery-1.11.2.min.js")
                .Include("~/scripts/rhythm/jquery.ajaxchimp.min.js")
                .Include("~/scripts/rhythm/jquery.appear.js")
                .Include("~/scripts/rhythm/jquery.countTo.js")
                .Include("~/scripts/rhythm/jquery.easing.1.3.js")
                .Include("~/scripts/rhythm/jquery.fitvids.js")
                .Include("~/scripts/rhythm/jquery.localScroll.min.js")
                .Include("~/scripts/rhythm/jquery.magnific-popup.min.js")
                .Include("~/scripts/rhythm/jquery.parallax-1.1.3.js")
                .Include("~/scripts/rhythm/jquery.scrollTo.min.js")
                .Include("~/scripts/rhythm/jquery.simple-text-rotator.min.js")
                .Include("~/scripts/rhythm/jquery.sticky.js")
                .Include("~/scripts/rhythm/jquery.viewport.mini.js")
                .Include("~/scripts/rhythm/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                .Include("~/scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/rhythm/allJS")
                .Include("~/scripts/rhythm/contact-form.js")
                            .Include("~/scripts/rhythm/imagesloaded.pkgd.min.js")
                            .Include("~/scripts/rhythm/isotope.pkgd.min.js")
                            .Include("~/scripts/rhythm/masonry.pkgd.min.js")
                            .Include("~/scripts/rhythm/owl.carousel.min.js")
                            .Include("~/scripts/rhythm/SmoothScroll.js")
                            .Include("~/scripts/rhythm/wow.min.js")
                            .Include("~/scripts/rhythm/placeholder.js")
                            .Include("~/scripts/rhythm/all.js"));



            bundles.Add(new ScriptBundle("~/bundles/rhythm/jqueryval").Include(
                "~/scripts/jquery.validate*",
                "~/scripts/jquery.unobtrusive*"));



            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/css/style.css",
                "~/Content/css/animate.min.css",
                "~/Content/css/bootstrap.min.css",
                "~/Content/css/magnific-popup.css",
                "~/Content/css/owl.carousel.css",
                "~/Content/css/style-responsive.css",
                "~/Content/css/vertical-rhythm.min.css"));
        }
    }
}