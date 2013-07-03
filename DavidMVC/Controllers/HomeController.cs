using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DavidMVC.Controllers
{
    public class HomeController : Controller
    {
        private int executeIndex = 1;
        private IList<string> executeInfoLs = new List<string>();
        private string executeInfo = string.Empty;

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            ViewBag.ExcuteLs = executeInfoLs;
            return View("Index");
        }

        public ActionResult About()
        {
            return View("About");
        }

        public ActionResult HttpExecuteInfo()
        {
            return View("HttpExecuteInfo");
        }

        public ActionResult UrlRoutePage()
        {
            return View("UrlRoutePage");
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            executeInfo = string.Format("{0}，OnAuthorization!", executeIndex);
            executeInfoLs.Add(executeInfo);
            executeIndex++;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {            
            executeInfo = string.Format("{0}，Before Action Execute!", executeIndex);
            executeInfoLs.Add(executeInfo);
            executeIndex++;            
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            executeInfo = string.Format("{0}，After Action Execute!", executeIndex);
            executeInfoLs.Add(executeInfo);
            executeIndex++;
        }

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            executeInfo = string.Format("{0}，Before Result Execute!", executeIndex);
            executeInfoLs.Add(executeInfo);
            executeIndex++;
        }

        /// <summary>
        /// 此时页面元素已经Render完毕
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            executeInfo = string.Format("{0}，After Result Execute!", executeIndex);
            executeInfoLs.Add(executeInfo);
            executeIndex++;
        }
    }
}
