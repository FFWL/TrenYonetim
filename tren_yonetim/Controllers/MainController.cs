using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tren_yonetim.Models.Entity;

namespace tren_yonetim.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        DbTrenYonetimEntities1 db = new DbTrenYonetimEntities1();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string yolcuad, string mail, string sifre)
        {
            tbl_musteri musteri = new tbl_musteri();
            string onay = "onaylandı";
            musteri.yolcuad = yolcuad;
            musteri.mail = mail;
            musteri.sifre = sifre;
            db.tbl_musteri.Add(musteri);
            db.SaveChanges();
            int musteriid =Convert.ToInt32(db.tbl_musteri.Where(x => x.yolcuad == yolcuad).Select(x => x.musteriid).FirstOrDefault());
            Session.Add("yolcuad", yolcuad);
            Session.Add("onay", onay);
            Session.Add("musteriid", musteriid);
           
            return RedirectToAction("Index", "Main");
        }
        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(string yolcuad, string sifre)
        {
            var musteri = db.tbl_musteri.Where(x => x.yolcuad == yolcuad && x.sifre == sifre).FirstOrDefault();
            string onay = "onaylandı";
            Session.Add("yolcuad", yolcuad);
            Session.Add("onay", onay);
            Session.Add("musteriid", musteri.musteriid);
            return RedirectToAction("Index", "Main");
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            return View("Index");
        }

    }
}