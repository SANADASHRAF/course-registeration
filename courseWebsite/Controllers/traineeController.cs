using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using courseWebsite.Models;

namespace courseWebsite.Controllers
{
    public class traineeController : Controller
    {
        coursedbcontect db = new coursedbcontect();
       

        #region course for tranee are subscribe by id course
        public ActionResult trainee(int? idcourse)
        {
             List<traineee_course>t=db.traineee_course.Where(n => n.course_id == idcourse).ToList();
            return View(t);
        }

        #endregion

        #region profile of trainee
        public ActionResult profile()
        {
            int id = (int)Session["user"];
            traineee tr = db.traineees.Where(n => n.id == id).FirstOrDefault();
            return View(tr);
        }
        #endregion

        #region course for tranee are subscribe by id trainee
        public ActionResult yourcourse(int? idtrainee)
        {
            List<traineee_course> li = db.traineee_course.Where(n => n.trainee_id ==idtrainee).ToList();
            return View(li);
        }

        #endregion

        #region yourcourse
        public ActionResult yourcoursee()
        {
            int id = (int)Session["user"];
            List<traineee_course> li = db.traineee_course.Where(n => n.trainee_id == id).ToList();
            return View(li);
        }
        #endregion
    }
}