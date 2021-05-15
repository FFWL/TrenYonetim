using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tren_yonetim.Models;
using tren_yonetim.Models.Entity;


namespace tren_yonetim.Controllers
{
    public class TrainController : Controller
    {
        // GET: Tren
        DbTrenYonetimEntities1 db = new DbTrenYonetimEntities1();

        public ActionResult Index()
        {
            var trenlistesi = db.tbl_tren.ToList();
            return View(trenlistesi);
        }
    }
}