using System.Web;
using System.Web.Optimization;

namespace Rhythm
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/rhythm/jquery")
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

            bundles.Add(new ScriptBundle("~/bundles/rhythm/bootstrap")
                .Include("~/Scripts/rhythm/bootstrap.js")
                .Include("~/Scripts/rhythm/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rhythm/all")
                .Include("~/Scripts/rhythm/all.js"));

            bundles.Add(new ScriptBundle("~/bundles/rhythm/contact")
                .Include("~/Scripts/rhythm/contact-form.js"));

            bundles.Add(new ScriptBundle("~/bundles/rhythm/imagesloaded")
                .Include("~/Scripts/rhythm/imagesloaded.pkgd.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rhythm/isotope")
                .Include("~/Scripts/rhythm/isotope.pkgd.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rhythm/masonry")
                .Include("~/Scripts/rhythm/masonry.pkgd.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rhythm/owl")
                .Include("~/Scripts/rhythm/owl.carousel.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/srhythm/moothScroll")
                .Include("~/Scripts/rhythm/SmoothScroll.js"));

            bundles.Add(new ScriptBundle("~/bundles/rhythm/wow")
                .Include("~/Scripts/rhythm/wow.min.js"));


            
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