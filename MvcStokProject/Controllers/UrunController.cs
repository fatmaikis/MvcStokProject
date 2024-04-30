using MvcStokProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using PagedList;
using PagedList.Mvc;
using System.Web.Mvc;

namespace MvcStokProject.Controllers
{
    public class UrunController : Controller
    {
        DbMVCStokEntities1 db = new DbMVCStokEntities1();
        public ActionResult Index(int sayfa=1)
        {
            //var value = db.TblUrunler.ToList();
            var value = db.TblUrunler.ToList().ToPagedList(sayfa,4);
            return View(value);
        }
        [HttpGet]
        public ActionResult EkleUrun()
        {
            List<SelectListItem> degerler = (from i in db.TblKategoriler.ToList() select new SelectListItem { 
                Text = i.KategoriAd, 
                Value = i.KategoriID.ToString() }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult EkleUrun(TblUrunler urunler)
        {
            var ktg = db.TblKategoriler.Where(m => m.KategoriID == urunler.TblKategoriler.KategoriID).FirstOrDefault();
            urunler.TblKategoriler = ktg;
            db.TblUrunler.Add(urunler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SilUrun(int id)
        {
            var value = db.TblUrunler.Find(id);
            db.TblUrunler.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GuncelleUrun(int id)
        {
          
            var value = db.TblUrunler.Find(id);
            List<SelectListItem> degerler = (from i in db.TblKategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAd,
                                                 Value = i.KategoriID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View(value); 
        }
        [HttpPost]
        public ActionResult GuncelleUrun(TblUrunler urunler)
        {
            var value = db.TblUrunler.Find(urunler.UrunID);
            value.UrunID = urunler.UrunID;
            value.UrunAd=urunler.UrunAd;
            value.Marka = urunler.Marka;
            //value.UrunKategori = urunler.UrunKategori;
            var ktg = db.TblKategoriler.Where(m => m.KategoriID == urunler.TblKategoriler.KategoriID).FirstOrDefault();
            value.UrunKategori = ktg.KategoriID;
            value.Fiyat = urunler.Fiyat;
            value.Stok=urunler.Stok;
            db.SaveChanges();
            return RedirectToAction("Index");   
        }
    }
}