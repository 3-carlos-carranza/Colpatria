
using System.Web.Optimization;

namespace Presentation.Web.Colpatria
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-2.8.3.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery.min.js",
                "~/Scripts/classie.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryMobile").Include(
                "~/Scripts/jquery.mobile-1.4.5.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                "~/Scripts/lib/jquery.livequery/jquery.livequery.js",
                "~/Scripts/lib/jquery.linq/linq.js",
                "~/Scripts/lib/jquery.gritter/jquery.gritter.js",
                "~/Scripts/lib/jquery.autonumeric/autoNumeric.js",
                "~/Scripts/lib/jquery.maskedinput/jquery.maskedinput-1.3.1.js",
                "~/Scripts/lib/jquery.validationengine/jquery.validationengine.js",
                "~/Scripts/lib/jquery.validationengine/jquery.validationengine-es.js",
                "~/Scripts/lib/jquery.form/jquery.form.js",
                "~/Scripts/lib/countdown/jquery.countdown.min.js",
                "~/Scripts/lib/countdown/jquery.countdown-es.js"
               

                ));


            bundles.Add(new ScriptBundle("~/bundles/jqueryUI").Include(
                ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/momentJS/moment.js",
                "~/Scripts/bootstrap/bootstrap.min.js",
                "~/Scripts/bootstrap/bootstrap-datetimepicker.min.js"


                ));

            bundles.Add(new ScriptBundle("~/bundles/layout").Include(
                "~/Scripts/lib/ieSupport/html5shiv.js",
                "~/Scripts/theme/mobileGeneral.js"
                ));


            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                "~/Scripts/kendo/2014.3.1119/kendo.all.min.js",
                "~/Scripts/kendo/2014.3.1119/kendo.aspnetmvc.min.js"
                ));


            /*
             */

            bundles.Add(new StyleBundle("~/Content/xtensions").Include(
                "~/Content/lib/jqueryUI/jquery-ui.css"
                ));

            bundles.Add(new StyleBundle("~/Content/layout").Include(
                "~/Content/lib/bootstrap/bootstrap.css",
                "~/Content/lib/kendo/kendo.css",
                "~/Content/lib/font-awesome/font-awesome.css",
                "~/Content/portal/styles.css"
                ));

            bundles.Add(new StyleBundle("~/Content/layoutLogin").Include(
                "~/Content/lib/bootstrap/bootstrap.css",
                "~/Content/lib/kendo/kendo.css",
                "~/Content/lib/font-awesome/font-awesome.css",
                "~/Content/portal/loginStyles.css"
                ));


            bundles.Add(new StyleBundle("~/Content/kendo").Include(
                "~/Content/lib/kendo/2014.3.1119/kendo.common.min.css",
                "~/Content/lib/kendo/2014.3.1119/kendo.mobile.all.min.css",
                "~/Content/lib/kendo/2014.3.1119/kendo.dataviz.min.css",
                "~/Content/lib/kendo/2014.3.1119/kendo.material.min.css",
                "~/Content/lib/kendo/2014.3.1119/kendo.dataviz.material.min.css"
                ));

            bundles.Add(new StyleBundle("~/Content/validations").Include(
                "~/Content/lib/jquery-validation-engine/validationengine.jquery.css",
                "~/Content/lib/jquery-validation-engine/normalize.css"
                ));

            bundles.Add(new StyleBundle("~/Content/loadingCss").Include(
                "~/Content/lib/bootstrap/bootstrap.css",
                "~/Content/lib/font-awesome/font-awesome.css",
                "~/Content/portal/loading.css"));

            bundles.Add(new ScriptBundle("~/bundles/xtensions").Include(
                "~/Scripts/lib/JqueryUI/jquery-ui.min.js",
                "~/Scripts/lib/xtensions/x-general.js",
                "~/Scripts/lib/xtensions/x-inputs.js",
                "~/Scripts/lib/xtensions/x-modal.js",
                "~/Scripts/lib/xtensions/x-kendo.js",
                "~/Scripts/lib/xtensions/x-forms.js",
                "~/Scripts/lib/xtensions/x-navigation.js",
                "~/Scripts/culture.js"
                ));
            bundles.IgnoreList.Clear();
            bundles.IgnoreList.Ignore("*.intellisense.js");
            bundles.IgnoreList.Ignore("*-vsdoc.js");
            bundles.IgnoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);

            BundleTable.EnableOptimizations = false;
        }
    }
}