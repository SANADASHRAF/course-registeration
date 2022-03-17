using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using courseWebsite.Models;

namespace courseWebsite.Controllers
{
    public class trainerrController : Controller
    {
        coursedbcontect db = new coursedbcontect();
        ////////////////////////////////////////////////////////////////////add trainer with admin
        #region add trainer by admin
        public ActionResult added()
        {
            return View();
        }
        [HttpPost]
        public ActionResult added(trainer t)
        {
            trainer x = db.trainers.Where(n => n.email == t.email).FirstOrDefault();
            if(x!=null)
            {
                ViewBag.massege2 = " envalid!!! email already exist! ";
                return View(t);
            }
            if(ModelState.IsValid)
            {
                ViewBag.done = true;
                ViewBag.massege2 = " DONE ,You already add this trainer. ";
                db.trainers.Add(t);
                db.SaveChanges();

                return View();
               
            }
            return View();
           
        }

        #endregion

        #region show admin
        public ActionResult Trainerr()
        {
            List<trainer> li = db.trainers.ToList();
            return View(li);
        }
       
        public ActionResult course(int? idcourse)
        {
            List<course> li = db.courses.Where(n => n.trainer_id == idcourse).ToList();
            trainer t = db.trainers.Where(n => n.id == idcourse).FirstOrDefault();
            if(li==null)
            {
                ViewBag.massega = $"There is no course asssign for trainer{t.name}";
            }
            return View(li);
        }
        #endregion
    }
}