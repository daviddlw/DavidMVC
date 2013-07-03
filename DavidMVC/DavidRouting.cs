using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DavidMVC.Models;

namespace DavidMVC
{
    public class HomeUrlProvider : RouteBase
    {
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var virtualPath = httpContext.Request.AppRelativeCurrentExecutionFilePath + httpContext.Request.PathInfo;

            virtualPath = virtualPath.Substring(2).Trim('/');

            if (!virtualPath.StartsWith("ca-"))
                return null;

            var categroyName = virtualPath.Split('-').Last();

            var category = CategoryProvider.AllCategories.Find(n => n.CategoryName.Equals(categroyName, StringComparison.OrdinalIgnoreCase));
            if (category == null)
                return null;

            var data = new RouteData(this, new MvcRouteHandler());
            data.Values.Add("controller", "Category");
            data.Values.Add("action", "ShowCategory");
            data.Values.Add("id", category.CategoryId);

            return data;
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            var categoryId = values["id"] as string;
            if (categoryId == null)
                return null;

            if (!values.ContainsKey("controller") || !values["controller"].ToString().Equals("category", StringComparison.OrdinalIgnoreCase))
                return null;

            if (!values.ContainsKey("action") || !values["action"].ToString().Equals("showcategory", StringComparison.OrdinalIgnoreCase))
                return null;

            var categroy = CategoryProvider.AllCategories.Find(n => n.CategoryId == categoryId);

            if (categroy == null)
                throw new ArgumentNullException("category");

            var path = string.Format("ca-{0}", categroy.CategoryName.ToString().Trim());
            return new VirtualPathData(this, path.ToLowerInvariant());
        }
    }
}