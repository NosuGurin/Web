using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ThucHanh1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Lấy đường dẫn file 
            string path = Server.MapPath("~/Visitors.txt");
            //Đọc số khách thăm webstie vào application
            Application["Visitors"] = int.Parse(File.ReadAllText(path));
        }

        protected void Session_Start()
        {
            Application.Lock(); // Khóa - tránh xung đột
            //Tăng số lượng khách thăm lên 1
            Application["Visitors"] = (int)Application["Visitors"] + 1;
            //Lấy đường dẩn file lưu số lượng khách thăm
            string path = Server.MapPath("~/Visitors.txt");
            //Ghi lại số lượng khách hàng thăm 
            File.WriteAllText(path, Application["Visitors"].ToString());
            Application.UnLock(); // Mở khóa
        }
    }
}
