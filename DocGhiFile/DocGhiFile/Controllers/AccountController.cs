using DocGhiFile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocGhiFile.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        //GET
        public ActionResult Register()
        {
            return View();
        }
        //POST
        [HttpPost]
        public ActionResult Register(UserInfo model)
        {
            //Lưu thông tin vào session
            Session["user"] = model;
            return View();
        }

        public ActionResult Profile()
        {
            //Chuyển về trang đăng ký nếu không có session
            if (Session["user"] == null)
            {
                return RedirectToAction("Register", "Account");
            }
            return View();
        }
        public ActionResult LogOff()
        {
            Session.Remove("user");
            return RedirectToAction("Register", "Account");
        }
    }
}