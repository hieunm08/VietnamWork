using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;
using TimKiemViecLam.Areas.Admin.Models;
using TimKiemViecLam.Common;

namespace TimKiemViecLam.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TaiKhoanModel model)
        {
            {
                if (ModelState.IsValid)
                {
                    var dao = new TaiKhoanDAO();
                    int result = dao.Login(model.TenDangNhap, model.MatKhau);
                    if (result == 1)
                    {
                        var user = dao.GetbyUser(model.TenDangNhap);
                        var user_Sesion = new UserLogin();
                        user_Sesion.TenDangNhap = user.TenDangNhap;
                        user_Sesion.HoTen = user.HoTen;
                        user_Sesion.ID_LoaiTaiKhoan = user.ID_LoaiTaiKhoan;
                        user_Sesion.ID_TaiKhoan = user.ID_TaiKhoan;

                        Session.Add("User_Session", user_Sesion);
                        //
                        if (user.ID_LoaiTaiKhoan != 1)
                        {
                            return Redirect("/Admin/Home/HomeMember");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }

                    }
                    else if (result == 0)
                    {
                        ModelState.AddModelError("", "Tài khoản không đúng !");
                    }
                    else
                        if (result == -1)
                    {
                        ModelState.AddModelError("", "Sai mật khẩu !");
                    }
                }
                return View("index");

            }
        }
    }
    }