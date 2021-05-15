using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using tren_yonetim.Models;
using tren_yonetim.Models.Entity;


namespace tren_yonetim.Controllers
{
    public class ReservationController : Controller
    {
        // GET: rezervasyon
        DbTrenYonetimEntities1 db = new DbTrenYonetimEntities1();
        public ActionResult Index()
        {
            int musteriid =Convert.ToInt32(Session["musteriid"]);
            if(Session["yolcuad"] == null)
            {
                return PartialView("~/Views/Main/Login.cshtml");
            }
            var rez = db.tbl_rezervasyon.Where(x => x.musteriid == musteriid).ToList();

            return View(rez);
        }
        public void dropdownlist(int id)
        {

            IEnumerable<SelectListItem> saatler = (from x in db.tbl_saatler.Where(x=>x.trenid == id).ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.saat,
                                                       Value = x.saatid.ToString()

                                                   }).ToList();
            IEnumerable<SelectListItem> vagons = (from x in db.tbl_vagon.Where(x => x.trenid == id).ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.vagonad,
                                                      Value = x.vagonid.ToString()

                                                  }).ToList();

            ViewData["saatler"] = saatler;
            ViewData["vagons"] = vagons;
        }

        public PartialViewResult customerlist()
        {


            IEnumerable<SelectListItem> yolcular = (from x in db.tbl_musteri.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.yolcuad,
                                                       Value = x.musteriid.ToString()

                                                   }).ToList();
            ViewData["yolcular"] = yolcular;
            return PartialView();
        }

        [HttpGet]
        public ActionResult AddReservation(int id)
        {
            Session.Add("trenid",id);
            dropdownlist(id);
            return View();
        }

        [HttpPost]
        public ActionResult AddReservation(string musteriisim,string [] yolcuad, string vagonad, string saat)
        {
            int trenid = Convert.ToInt32(Session["trenid"]);
            tbl_rezervasyon rez = new tbl_rezervasyon();
            tbl_musteri musteri = new tbl_musteri();
            tbl_vagon vagon = new tbl_vagon();
            int vagon_id = Convert.ToInt32(vagonad);
            var musid = db.tbl_musteri.Where(x => x.yolcuad == musteriisim).Select(x => x.musteriid).FirstOrDefault();

            if(musid == 0)
            {
                dropdownlist(trenid);

                ViewBag.Error2 = "Kişi bulunamadı";
                return View("RezEkle");
            }
            else
            {
                var vagonid = db.tbl_vagon.Where(x => x.vagonid == vagon_id).Select(x => x.vagonid).FirstOrDefault();
                var vagon2 = db.tbl_vagon.Find(vagonid);
                int vagon_kapasite =Convert.ToInt32(vagon2.doluluk_orani) + Convert.ToInt32(yolcuad.Length);
                double total_kapasite = Convert.ToDouble(vagon_kapasite) / Convert.ToDouble(vagon2.kapasite);
                if (total_kapasite > 0.7)
                {
                     dropdownlist(trenid);
                    ViewBag.Error = "Seçtiğiniz vagonda yer bulunmamaktadır.";
                    return View("RezEkle");
                }

                rez.rezkisisayisi = Convert.ToInt32(yolcuad.Length);
                rez.musteriid = Convert.ToInt32(musid);
                rez.vagonid = Convert.ToInt32(vagonid);
                rez.tarih = saat;

                vagon2.doluluk_orani += Convert.ToInt32(vagon_kapasite);

                db.tbl_rezervasyon.Add(rez);
                db.SaveChanges();

                return RedirectToAction("Index", "Main");
            }
        }
    }
}