using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;

namespace TimKiemViecLam.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
       /* public ActionResult Index()
        {
            var dao = new Da();
            var model = dao.listByHome();
            return View(model);
        }*/
        public ActionResult HomeMember()
        {
            return View();
        }
    }
}