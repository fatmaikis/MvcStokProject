using MvcStokProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStokProject.Controllers
{
    public class SatisController : Controller
    {
        DbMVCStokEntities1 db = new DbMVCStokEntities1 ();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(TblSatislar satislar)
        {
            var value =db.TblSatislar.Add (satislar);
            db.SaveChanges();
           return View("Index");    
        }
    }
}