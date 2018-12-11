using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThucHanh1.Models;

namespace ThucHanh1.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (model.UserName == "hoaibac" && model.Password == "123456")
            {
                //Duy trì thông tin đăng nhập vào session
                Session["user"] = model;

                //Xử lý việc ghi nhớ tài khoản bằng session
                var cookie = new HttpCookie("user");
                cookie.Values["id"] = model.UserName;
                cookie.Values["pw"] = model.Password;
                if (model.Remember == true)
                {
                    cookie.Expires = DateTime.Now.AddMonths(1);
                }
                else
                {
                    cookie.Expires = DateTime.Now.AddMonths(-1);
                }
                //Gửi cookie về client lưu lại
                Response.Cookies.Add(cookie);
            }
            return View();
        }

        public ActionResult Profile()
        {
            //Chuyển về trang đăng nhập nếu người dùng không tồn tại
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        public ActionResult LogOff()
        {
            Session.Remove("user");
            return RedirectToAction("Login","Account");
        }
    }
}