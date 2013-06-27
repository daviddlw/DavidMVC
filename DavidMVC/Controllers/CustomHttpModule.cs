using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DavidMVC.HttpModules
{
    public class CustomHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(App_Begin);
            context.EndRequest += new EventHandler(App_End);
        }

        private void App_Begin(object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;
            if (app != null)
                app.Context.Response.Write("<h2>自定义模块BeginRequest</h2>");
        }

        private void App_End(object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;
            if (app != null)
                app.Context.Response.Write("<h2>自定义模块EndRequest</h2>");
        }

        public void Dispose() { }
    }
}