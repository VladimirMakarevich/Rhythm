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
                .Include("~/scripts/rhythm/jquery.viewport.mini.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                .Include("~/scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/rhythm/bootstrap")
                .Include("~/scripts/rhythm/bootstrap.js")
                .Include("~/scripts/rhythm/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rhythm/all")
                .Include("~/scripts/rhythm/all.js"));

            bundles.Add(new ScriptBundle("~/bundles/rhythm/contact")
                .Include("~/scripts/rhythm/contact-form.js"));

            bundles.Add(new ScriptBundle("~/bundles/rhythm/imagesloaded")
                .Include("~/scripts/rhythm/imagesloaded.pkgd.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rhythm/isotope")
                .Include("~/scripts/rhythm/isotope.pkgd.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rhythm/masonry")
                .Include("~/scripts/rhythm/masonry.pkgd.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/rhythm/owl")
                .Include("~/scripts/rhythm/owl.carousel.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/srhythm/moothScroll")
                .Include("~/scripts/rhythm/SmoothScroll.js"));

            bundles.Add(new ScriptBundle("~/bundles/rhythm/wow")
                .Include("~/scripts/rhythm/wow.min.js"));
        
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