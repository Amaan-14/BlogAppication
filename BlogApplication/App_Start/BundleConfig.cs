using System.Web;
using System.Web.Optimization;

namespace BlogApplication
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {


            bundles.Add(new ScriptBundle("~/bundles/Particles").Include(
                 "~/Scripts/ParticlesJs/particles.js",
                     "~/Scripts/ParticlesJs/app.js",
                     "~/Scripts/ParticlesJs/js.js",
                     "~/Scripts/NavJs/jquery.sticky.js",
                     "~/Scripts/NavJs/main.js"
                    ));

            bundles.Add(new ScriptBundle("~/bundles/AdminNavJs").Include(
              "~/Scripts/AdminNavJs/sidebarmenu.js",
                  "~/Scripts/AdminNavJs/app.min.js"
                  ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/js/bootstrap.min.js",
                      "~/Scripts/NavJs/owl.carousel.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/ParticleCss/media.css",
                      "~/Content/Blogcss/style.css",
                      "~/Content/Blogcss/Responsive.css",
                      "~/Content/NavCss/style.css",
                      "~/Content/NavCss/iconstyle.css"
                     ));

            bundles.Add(new StyleBundle("~/Admin/CSS").Include(
                      "~/Content/AdminCss/styles.min.css"));


        }
    }
}
