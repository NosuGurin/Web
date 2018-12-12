using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThucHanh1.Models;

namespace ThucHanh1.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult List()
        {
            var list = new List<ProductInfo>()
            {
                new ProductInfo{Name="Nokia 2014" , Price = 1000},
                new ProductInfo{Name="Samsung Galaxy" , Price = 1500},
                new ProductInfo{Name="iPhone 5" , Price = 3000},
                new ProductInfo{Name="Sony Erricson 17" , Price = 200},
                new ProductInfo{Name="Seamen 2015" , Price = 1300},
                new ProductInfo{Name="Dell Star" , Price = 1600},
                new ProductInfo{Name="Sony Vios" , Price = 2400},
                new ProductInfo{Name="Acer Xyy" , Price = 70},

            };
            return View(list);
        }

        public ActionResult Detail(string Name)
        {
            //Lấy cookie từ client
            var cookie = Request.Cookies["Items"];
            if (cookie == null)
            {
                //Tạo mới vì trước đó khách hàng chưa xem mặt hàng nào
                cookie = new HttpCookie("Items");
            }
            var value = cookie.Values[Name];
            if (value == null)
            {
                //Bổ sung sản phẩm vừa xem vào cookie
                cookie.Values[Name] = 1.ToString();
            }
            else
            {
                //Tăng số lần xem lên 1
                cookie.Values[Name] = (int.Parse(cookie.Values[Name]) + 1).ToString();
            }

            //Đặt thời gian tồn tại cho cookie là 1 tháng
            cookie.Expires = DateTime.Now.AddMonths(1);
            //Gửi cookie để lưu về client
            Response.Cookies.Add(cookie);

            return RedirectToAction("List"); //quay trở về trang danh sách sản phẩm
        }

        public ActionResult Remove(string Name)
        {
            //Lấy cookie từ client
            var cookie = Request.Cookies["Items"];
            //Xóa bớt giá trị
            cookie.Values.Remove(Name);
            if (!cookie.Values.HasKeys())
            {
                cookie.Expires = DateTime.Now.AddMonths(-1);//Xóa luôn cookie
            }
            else
            {
                cookie.Expires = DateTime.Now.AddMonths(1);
            }
            //Gửi cookie về client
            Request.Cookies.Add(cookie);

            return RedirectToAction("List");
        }
    }
}