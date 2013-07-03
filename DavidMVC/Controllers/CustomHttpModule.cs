using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DavidMVC.HttpModules
{
    /// <summary>
    /// 在执行真正的Http请求（HttpHandler）之前对附加一些信息到Http请求上
    /// </summary>
    public class CustomHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            //context.BeginRequest += new EventHandler(App_RequestBegin);
            //context.PreSendRequestHeaders += new EventHandler(App_PreSendRequestHeaders);
            //context.PreSendRequestContent += new EventHandler(App_PreSendRequestContent);
            //context.EndRequest += new EventHandler(App_RequestEnd);
            //context.AuthenticateRequest += new EventHandler(App_AuthenticateRequest);
            //context.AuthorizeRequest += new EventHandler(App_AuthorizeRequest);
            //context.ResolveRequestCache += new EventHandler(App_ResolveRequestCache);
            //context.AcquireRequestState += new EventHandler(App_AcquireRequestState);
            //context.PreRequestHandlerExecute += new EventHandler(App_PreRequestHandler);
            //context.PostRequestHandlerExecute += new EventHandler(App_PostRequestHandlerExecute);
            //context.UpdateRequestCache += new EventHandler(App_UpdateRequestCache);
            //context.ReleaseRequestState += new EventHandler(App_ReleaseRequestState);

        }

        private string ProcessStr(string sourceStr)
        {
            return string.Format("<span style='font-size:small;'><strong>{0}</strong><span><br/>", sourceStr);
        }

        private void App_RequestBegin(object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;
            if (app != null)
            {
                HttpContext context = app.Context;
                HttpRequest request = app.Request;
                HttpResponse response = app.Response;

                app.Context.Response.AppendHeader("davidtag", "david_unique_page");
                response.Write(ProcessStr("App_RequestBegin"));
            }
        }

        private void App_RequestEnd(object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;
            if (app != null)
            {
                HttpContext context = app.Context;
                HttpRequest request = app.Request;
                HttpResponse response = app.Response;

                response.Write(ProcessStr("App_RequestEnd"));
            }
        }

        private void App_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;
            if (app != null)
            {
                app.Context.Response.Write(ProcessStr("App_AuthenticateRequest"));
            }
        }

        private void App_AuthorizeRequest(object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;
            if (app != null)
            {
                app.Context.Response.Write(ProcessStr("App_AuthorizeRequest"));
            }
        }

        private void App_ResolveRequestCache(object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;
            if (app != null)
            {
                app.Context.Response.Write(ProcessStr("App_ResolveRequestCache"));
            }
        }

        private void App_AcquireRequestState(object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;
            if (app != null)
            {
                app.Context.Response.Write(ProcessStr("App_AcquireRequestState"));
            }
        }

        private void App_PreRequestHandler(object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;
            if (app != null)
            {
                app.Context.Response.Write(ProcessStr("App_PreRequestHandler"));
            }
        }

        private void App_ProcessRequest(object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;
            if (app != null)
            {
                app.Context.Response.Write(ProcessStr("App_ProcessRequest"));
            }
        }

        private void App_PostRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;
            if (app != null)
            {
                app.Context.Response.Write(ProcessStr("App_PostRequestHandlerExecute"));
            }
        }

        private void App_ReleaseRequestState(object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;
            if (app != null)
            {
                app.Context.Response.Write(ProcessStr("App_ReleaseRequestState"));
            }
        }

        private void App_UpdateRequestCache(object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;
            if (app != null)
            {
                app.Context.Response.Write(ProcessStr("App_UpdateRequestCache"));
            }
        }

        private void App_PreSendRequestHeaders(object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;
            if (app != null)
            {
                app.Context.Response.Write(ProcessStr("App_PreSendRequestHeader"));
            }
        }

        private void App_PreSendRequestContent(object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;
            if (app != null)
            {
                app.Context.Response.Write(ProcessStr("App_PreSendRequestContent"));
            }
        }

        public void Dispose() { }
    }
}

namespace DavidMVC
{
    public class CustomHttpHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.Write(ProcessStr("ProcessRequest"));
        }

        private string ProcessStr(string sourceStr)
        {
            return string.Format("<span style='font-size:small;'><strong>{0}</strong><span><br/>", sourceStr);
        }
    }
}