using MvcStokProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStokProject.Controllers
{
    public class MusteriController : Controller
    {
        DbMVCStokEntities1 db = new DbMVCStokEntities1 ();
        public ActionResult Index(string p)
        {
            var degerler = from d in db.TblMusteriler select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(x => x.MusteriAd.Contains(p));
            }
            return View(degerler.ToList());
            //var value = db.TblMusteriler.ToList();
            //return View(value);
        }
        [HttpGet]
        public ActionResult EkleMusteri()
        {
            return View();
        }
        public ActionResult EkleMusteri(TblMusteriler musteriler)
        {
            if (!ModelState.IsValid)
            {
                return View("EkleMusteri");
            }
            var value = db.TblMusteriler.Add(musteriler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SilMusteri(int id)
        {
            var value = db.TblMusteriler.Find(id);
            db.TblMusteriler.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GüncelleMusteri(int id)
        {
            var value = db.TblMusteriler.Find(id);
            return View(value); 
        }
        [HttpPost]
        public ActionResult GüncelleMusteri(TblMusteriler musteriler)
        {
            var value = db.TblMusteriler.Find(musteriler.MusteriID);
            value.MusteriID = musteriler.MusteriID;
            value.MusteriAd = musteriler.MusteriAd;
            value.MusteriSoyad = musteriler.MusteriSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        
    }
}