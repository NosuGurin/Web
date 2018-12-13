using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThucHanh2.Models;

namespace ThucHanh2.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Validate()
        {
            return View();
        }
        [HttpPost , ValidateAntiForgeryToken]
        public ActionResult Validate(Employee model)
        {
            if (ModelState.IsValid)
            {
                ModelState.AddModelError("", "Bạn đã nhập đúng !");
            }
            return View();
        }

        public ActionResult ManualValidate()
        {
            return View();
        }
        [HttpPost , ValidateInput(false)]
        public ActionResult ManualValidate(String Description)
        {
            return View();
        }
    }
}