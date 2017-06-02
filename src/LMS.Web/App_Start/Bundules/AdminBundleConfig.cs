using System.Web.Optimization;

namespace LMS.Web.Bundules
{
    public static class AdminBundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //LIBRARIES
            AddAdminCssLibs(bundles);
            AddAdminLTECss(bundles);

            bundles.Add(
                new ScriptBundle("~/Bundles/Admin/libs/js")
                    .Include(
                        ScriptPaths.Json2,
                        ScriptPaths.JQuery,
                        ScriptPaths.JQuery_UI,
                        ScriptPaths.JQuery_Validation,
                        ScriptPaths.JQuery_Knob,
                        ScriptPaths.JQuery_DataTables,
                        //ScriptPaths.JQuery_Ajax_Form,
                        ScriptPaths.MomentJs,
                        ScriptPaths.MomentTimezoneJs,
                        ScriptPaths.Bootstrap,
                        ScriptPaths.Bootstrap_Hover_Dropdown,
                        ScriptPaths.Bootstrap_Switch,
                        ScriptPaths.Bootstrap_DateRangePicker,
                        ScriptPaths.Bootstrap_Select,
                        ScriptPaths.Bootstrap_DataTables,
                        ScriptPaths.Wysihtml5,
                        ScriptPaths.Prettify,
                        //ScriptPaths.Bootstrap_Wysihtml5,
                        ScriptPaths.JQuery_SlimScroll,
                        ScriptPaths.JQuery_BlockUi,
                        ScriptPaths.JQuery_Confirm,
                        ScriptPaths.Js_Cookie,
                        ScriptPaths.JsTree,
                        ScriptPaths.SignalR,
                        ScriptPaths.LocalForage,
                        ScriptPaths.Raphael,
                        ScriptPaths.Morris,
                        ScriptPaths.ICheck,
                        ScriptPaths.ZTree,
                        ScriptPaths.SpinJs,
                        ScriptPaths.SpinJs_JQuery,
                        ScriptPaths.SweetAlert,
                        ScriptPaths.Sparkline,
                        ScriptPaths.Toastr,
                        ScriptPaths.Underscore,
                        ScriptPaths.Abp,
                        ScriptPaths.Abp_JQuery,
                        ScriptPaths.Abp_Toastr,
                        ScriptPaths.Abp_BlockUi,
                        ScriptPaths.Abp_SpinJs,
                        ScriptPaths.Abp_SweetAlert,
                        ScriptPaths.Abp_Moment,
                        ScriptPaths.Abp_jTable
                    ).ForceOrdered()
                );

            //AdminLTE
            bundles.Add(
              new ScriptBundle("~/Bundles/Admin/js")
                  .Include(
                      "~/AdminLTE/js/adminlte.js",
                      "~/AdminLTE/js/demo.js"
                  ).ForceOrdered()
              );
        }

        private static void AddAdminCssLibs(BundleCollection bundles)
        {
            bundles.Add(
                new StyleBundle("~/Bundles/Admin/libs/css")
                    .Include(StylePaths.JQuery_UI, new CssRewriteUrlTransform())
                    .Include(StylePaths.JQuery_Confirm, new CssRewriteUrlTransform())
                    .Include(StylePaths.FontAwesome, new CssRewriteUrlTransform())
                    .Include(StylePaths.Ionicons, new CssRewriteUrlTransform())
                    .Include(StylePaths.ZTree, new CssRewriteUrlTransform())
                    .Include(StylePaths.JsTree, new CssRewriteUrlTransform())
                    .Include(StylePaths.Morris, new CssRewriteUrlTransform())
                    .Include(StylePaths.SweetAlert, new CssRewriteUrlTransform())
                    .Include(StylePaths.Toastr, new CssRewriteUrlTransform())
                    .Include(StylePaths.Bootstrap, new CssRewriteUrlTransform())
                    .Include(StylePaths.JQuery_DataTbales, new CssRewriteUrlTransform())
                    .Include(StylePaths.Bootstrap_DateRangePicker, new CssRewriteUrlTransform())
                    .Include(StylePaths.Bootstrap_Switch, new CssRewriteUrlTransform())
                    .Include(StylePaths.Bootstrap_Select, new CssRewriteUrlTransform())
                    .Include(StylePaths.Prettify, new CssRewriteUrlTransform())
                    //.Include(StylePaths.Bootstrap_Wysihtml5, new CssRewriteUrlTransform())
                    .Include(StylePaths.ICheck, new CssRewriteUrlTransform())
                    .ForceOrdered()
                );
        }

        private static void AddAdminLTECss(BundleCollection bundles)
        {
            bundles.Add(
                new StyleBundle("~/Bundles/AdminLTE/css")
                    .Include("~/AdminLTE/css/AdminLTE.css", new CssRewriteUrlTransform())
                    .Include("~/AdminLTE/css/skins/_all-skins.min.css", new CssRewriteUrlTransform())
                    .ForceOrdered()
                );
        }
    }
}