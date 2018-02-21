using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WisaJobBoard.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Hello(string name, int loop = 1)
        {
            ViewBag.Message = string.Format("Hello {0}", name);
            ViewBag.Loop = loop;

            return View();
        }
    }
}