using System.Web.Optimization;

namespace LMS.Web.Bundules
{
    public static class CommonBundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(
                new StyleBundle("~/Bundles/Common/css")
                    .IncludeDirectory("~/Content/Common", "*.css", true)
                    .ForceOrdered()
                );

            bundles.Add(
                new ScriptBundle("~/Bundles/Common/js")
                    .IncludeDirectory("~/Scripts/Common", "*.js", true)
                    .ForceOrdered()
                );

        }
    }
}