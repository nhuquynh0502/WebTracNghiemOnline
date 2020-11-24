using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTracNghiemOnline.Helpers;
using WebTracNghiemOnline.Models;

namespace WebTracNghiemOnline.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DangNhap()
        {
            return View();
        }
        public ActionResult DangKy()
        {
            return View();
        }
        public ActionResult QuenMatKhau()
        {
            return View();
        }
        [HttpPost]
        public ActionResult QuenMatKhau(string email)
        {
            string err;
            bool kq = new AccountHelper().QuenMatKhau(email,out err);
            if(kq == true)
            {
                return View("DangNhap");
            }
            else
            {
                ViewBag.ErrorMessage = err;
                return View();
            }
        }

        [HttpPost]
        public ActionResult DangKy(DangKyModel model)
        {
            string err;
            bool kq = new AccountHelper().DangKy(model, out err);
            if(kq == true)
            {
                return View("Index");
            }
            else
            {
                ViewBag.ErrorMessage = err;
                return View();
            }
        }
        [HttpPost]
        public ActionResult DangNhap(DangNhapModel model)
        {
            string err;
            bool kq = new AccountHelper().DangNhap(model,out err);
            if(kq == true)
            {
                return View("Index");
            }
            else
            {
                ViewBag.ErrorMessage = err;
                return View();
            }
        }
    }
}