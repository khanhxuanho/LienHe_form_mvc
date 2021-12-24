using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using BaiLH.Context;
using BaiLH.Models;


namespace BaiLH.Controllers
{
    public class HomeController : Controller
    {


        // ket noi csdl
        LienLacEntities obj = new LienLacEntities();

        // GET: Home
        public ActionResult Index()
        {
            var Ten = obj.LienHes.ToList();// lien he lay het
                                           // var Phone =
            Danhsach ds = new Danhsach();
            ds.ListLH = Ten;

            return View(ds);

        }

        [HttpGet]// de chay trc
        public ActionResult Create(string HTTP_USER_AGENT, string myCookie)
        {
            ViewData["HTTP_USER_AGENT"] = HTTP_USER_AGENT;
            ViewData["myCookie"] = myCookie;
           return View();
        }
        public ActionResult CreateCookie(string cookieValue)
        {
            var newCookie = new HttpCookie("myCookie", cookieValue);
            newCookie.Expires = DateTime.Now.AddDays(10);
            Response.AppendCookie(newCookie);
            return RedirectToAction("Index");
        }

        //khai bao de chay validate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LienHe LH)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Disable entity validation
                    obj.Configuration.ValidateOnSaveEnabled = false;
                    Danhsach ds = new Danhsach();
                    obj.LienHes.Add(LH);
                    obj.SaveChanges();
                    
                    // return Json(_user, JsonRequestBehavior.AllowGet);
                    return RedirectToAction("Create");  // tra ve trang ...
                }
                return View();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }
    



        // hien ajax
    [HttpPost]
    public ActionResult LoadAjax(LienHe lh)//FormCollection f
        {
            string KQ = lh.Ten;  //f["Ten"].ToString();
            String Phone = lh.Phone;  //f["Phone"].ToString();

            return Content(KQ+"  "+ Phone);// ve noi dung
        }
    }
}