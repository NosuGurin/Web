using DocGhiFile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocGhiFile.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Manage(StudentInfo model,string command)
        {
            string path = Server.MapPath("~/Student.txt");
            if (command == "Lưu")
            {
                string[] lines = { model.Id, model.Name, model.Marks.ToString() };
                System.IO.File.WriteAllLines(path,lines);
                ViewBag.Message = "Đã ghi vào file !";

            }
            else
            {
                string[] lines = System.IO.File.ReadAllLines(path);
                ViewBag.Id = lines[0];
                ViewBag.Name = lines[1];
                ViewBag.Marks = Convert.ToDouble(lines[2]);

                ViewBag.Message = "Đã đọc từ file !";
            }
            return View("Index");
        }
    }
}