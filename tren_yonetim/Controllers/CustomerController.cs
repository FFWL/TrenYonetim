using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tren_yonetim.Models;
using tren_yonetim.Models.Entity;

namespace tren_yonetim.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        DbTrenYonetimEntities1 db = new DbTrenYonetimEntities1();
        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(tbl_musteri p)
        {
            db.tbl_musteri.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index","Main");
        }

        public ActionResult Index()
        {
            var musteri = db.tbl_musteri.ToList();
            return View(musteri.FirstOrDefault());
        }
    }
}