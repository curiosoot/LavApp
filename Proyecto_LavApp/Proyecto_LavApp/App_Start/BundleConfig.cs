using System.Web;
using System.Web.Optimization;

namespace Proyecto_LavApp
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/sweetalert/js").Include(
                "~/Content/libs/sweetalert/sweetalert2.all.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/sweetalert/css").Include(
               "~/Content/libs/sweetalert/sweetalert2.css"
               ));

            bundles.Add(new ScriptBundle("~/bundles/datatables/js").Include(
                "~/Content/libs/datatables/datatables.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/datatables/css").Include(
               "~/Content/libs/datatables/datatables.css"
               ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Content/libs/datatables/datatables.js",
                      "~/Content/libs/sweetalert/sweetalert2.all.js"                      
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/dashboard.css",
                      "~/Content/libs/sweetalert/sweetalert2.css",
                      "~/Content/libs/datatables/datatables.css",
                      "~/Content/libs/fontawesome/css/all.css",
                      "~/Content/site.css"));
        }
    }
}
