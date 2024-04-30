using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using MvcStokProject.Models.Entity;

namespace MvcStokProject.Controllers
{
    public class KategoriController : Controller
    {
        DbMVCStokEntities1 db = new DbMVCStokEntities1 ();
        
        public ActionResult Index(int sayfa=1)
        {
          
            //var value = db.TblKategoriler.ToList();
            var degerler =db.TblKategoriler.ToList().ToPagedList(sayfa,4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult EkleKategori()
        {
            return View();  
        }
        [HttpPost]
        public ActionResult EkleKategori(TblKategoriler kategoriler)
        {
            if (!ModelState.IsValid)
            {
                return View("EkleKategori");
            }
            db.TblKategoriler.Add(kategoriler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SilKategori(int id)
        {
            var value = db.TblKategoriler.Find(id);
            db.TblKategoriler.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");   
        }

        [HttpGet]
        public ActionResult GuncelleKategori(int id)
        {
            var value = db.TblKategoriler.Find(id);
            return View(value); 
        }

        [HttpPost]
        public ActionResult GuncelleKategori(TblKategoriler kategoriler)
        {
            var value = db.TblKategoriler.Find(kategoriler.KategoriID);
            value.KategoriID = kategoriler.KategoriID;
            value.KategoriAd=kategoriler.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}