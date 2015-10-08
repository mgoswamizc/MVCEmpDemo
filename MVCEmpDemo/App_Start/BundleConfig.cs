using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MVCEmpDemo.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/Scripts/js").Include("~/Scripts/jquery-2.1.4.min.js",
            //                                                     "~/Scripts/bootstrap.min.js"));
            //bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.min.css",
            //                                                    "~/Content/bootstrap-theme.min.css"));
            bundles.Add(new ScriptBundle("~/Content/js").Include("~/Content/jquery.js",
                                                                 "~/Content/bootstrap/js/bootstrap.min.js"));
            //adding css
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap/css/bootstrap.min.css"));
        }
        
    }
}