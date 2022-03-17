using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using courseWebsite.Models;


namespace courseWebsite.Controllers
{
    public class adminController : Controller
    {


        coursedbcontect db = new coursedbcontect();
      

        ////////////////////////////////login  
        #region login
        public ActionResult login()
        {
            return View();
        }

     [HttpPost]
        public ActionResult login(string email,string password)
        {
            admin s = db.admins.Where(n => n.email == email && n.password == password).FirstOrDefault();
            traineee tr = db.traineees.Where(n => n.email == email && n.password == password).FirstOrDefault();

            if (s  !=null)
            {
                    //session
                Session.Add("ID", s.id);
                return RedirectToAction("home");

            }
           else  if (tr != null)
            {
                //session
                Session.Add("user", tr.id);
                return RedirectToAction("home");

            }
            else
            {     
                ViewBag.status = "invalid data!";
                return View(email, password);
            }
           
        }
        #endregion
        #region log out
        public ActionResult logout()
        {
            Session["ID"] = null;
            return RedirectToAction("login", "admin");
        }
        #endregion
        #region sign up trainee
        public ActionResult signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult signup(traineee t,HttpPostedFileBase imag)
        {
            imag.SaveAs(Server.MapPath("~/attach/userimg/" + imag.FileName));
            t.img = imag.FileName;

            t.creation_date = DateTime.Now;

            traineee x = db.traineees.Where(n => n.email == t.email).FirstOrDefault();
            if(x!=null)
            {
                ViewBag.massege4 = $"the user of this email {t.email}is exist before!!";
                return View(t);
            }
            if(ModelState.IsValid)
            {
                db.traineees.Add(t);
                db.SaveChanges();
                return RedirectToAction("login", "admin");
            }
            return View();
        }
        #endregion 
        #region where go after login
        public ActionResult profile()
        {
            return View();
        }
        #endregion


        /////////////////////////////////////////////////////////////////////category
        #region show category 
        public ActionResult category()
        {
            List<category> li = db.categories.ToList();
            return View(li);
        }
        #endregion
        #region add category
        public ActionResult create()
        {
            SelectList s3 = new SelectList(db.categories.ToList(), "id", "name");
            
            ViewBag.masge = s3;
            return View();
        }

      [HttpPost]
        public ActionResult create(category c)
        {
            
            category s = db.categories.Where(n => n.name == c.name).FirstOrDefault();
            if(s!=null)
            {
                ViewBag.massega = "name of category is already exist!";
                return View(c);
            }
            if(ModelState.IsValid)
            {
                db.categories.Add(c);
                db.SaveChanges();
                return RedirectToAction("category", "admin");
            }
            return View();
        }
        #endregion
        #region edit category
        public ActionResult edit(int? id)
        {
            category x = db.categories.Where(n => n.id == id).FirstOrDefault();
            SelectList li = new SelectList(db.categories.ToList(), "id", "name");
            ViewBag.drobdownlist = li;
            return View(x);
        }
        [HttpPost]
        public ActionResult edit(category s)
        {
            category namee = db.categories.Where(n => n.name == s.name).FirstOrDefault();
            if (namee != null)
            {
                ViewBag.edit = false;
                ViewBag.massege = $"the update of category ({namee.id}) is exist!!";
                return View(s);
            }
            s.ToString().ToLower();
            db.Entry(s).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("category");
           
        }

        #endregion      
        #region delete category
        public ActionResult delete(int? id )
        {
            category x = db.categories.Where(n => n.id == id).FirstOrDefault();
            return View(x);
        }

        [HttpPost]
        public ActionResult delete(category s)
        {
            category x = db.categories.Where(n => n.id == s.id).SingleOrDefault();
            ViewBag.massege1 = $"Do you want to delet category of id {x.id} ? ";
            db.categories.Remove(x);
            db.SaveChanges();
            return RedirectToAction("category");
            
        }
        #endregion


        //////////////////////////////////////////////////////////////////// courses
        #region course
        public ActionResult course()
        {

            List<course> li = db.courses.ToList();
            //SelectList li1 = new SelectList(db.trainers.ToList(), "id", "name");
            //SelectList li2 = new SelectList(db.categories.ToList(), "id", "name");
            //SelectList li3 = new SelectList(db.courses.ToList(), "id", "name");
            //ViewBag.m1 = li1;
            //ViewBag.m2 = li2;
            //ViewBag.m3 = li3;
            return View(li);
        }
        
        #endregion

        #region delete course
        public ActionResult deleteCourse(int? id)
        {
            course x = db.courses.Where(n => n.id == id).FirstOrDefault();
            return View(x);
        }
        [HttpPost]
        public ActionResult deleteCourse(course c)
        {
            course c2 = db.courses.Where(n => n.id == c.id).FirstOrDefault();
            db.courses.Remove(c2);
            db.SaveChanges();
            return RedirectToAction("course");
        }
        #endregion
        #region add courses

        public ActionResult AddCourse()
        {
            
            SelectList s1 = new SelectList(db.categories.ToList(), "id", "name");
            SelectList s2 = new SelectList(db.trainers.ToList(), "id", "name");
            ViewBag.li1 = s1;
           
            ViewBag.li2 = s2;
            return View();
        }

        [HttpPost]
        public ActionResult AddCourse(course c,HttpPostedFileBase imag)
        {

           
           
            imag.SaveAs(Server.MapPath("~/attach/ "+imag.FileName));
            c.img = imag.FileName;
            c.create_date = DateTime.Now;
                db.courses.Add(c);
                db.SaveChanges();

            return RedirectToAction("course");
        }
        public ActionResult x()
        {
            return View();
        }

        #endregion

        #region edit course
        public ActionResult EditCourse(int? id)
        {
            course x = db.courses.Where(n => n.id == id).FirstOrDefault();
            SelectList s1 = new SelectList(db.categories.ToList(), "id", "name");
            SelectList s2 = new SelectList(db.trainers.ToList(), "id", "name");
            ViewBag.li1 = s1;

            ViewBag.li2 = s2;
            return View(x);
        }
        [HttpPost]
        public ActionResult EditCourse(course c)
        {
            db.Entry(c).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("course");
        }
        #endregion

        /////////////////////////////////////////////////////////////////////////home
        #region home
        public ActionResult home()
        {
            List<course> li = db.courses.ToList();
            return View(li);
        }
        #endregion


       /////////////////////////////////////////////////////////////////////////////subacribe in course
               
        #region Subscribe to the course
        public ActionResult subscribe(int? course_id)
        {
            course c = db.courses.Where(n => n.id == course_id).SingleOrDefault();
            
            return View(c);
        }



        public ActionResult couressubscribe( traineee_course tr)
        {
            
            int id = (int)Session["user"];
            tr.trainee_id = id;
            tr.register_date = DateTime.Now;

            db.traineee_course.Add(tr);
            db.SaveChanges();
            return RedirectToAction("home","admin");
        }
        #endregion
        //////////////////////////////////////////////////////////////////////////////show and delete trainee
        #region show trainee
            public ActionResult traineee()
        {
            List<traineee> tr = db.traineees.ToList();
            return View(tr);
        }

        #endregion

        #region delete trainee
        public ActionResult deletetraine(int? id)
        {
            traineee tr = db.traineees.Where(n => n.id == id).FirstOrDefault();
            return View(tr);
        }
        [HttpPost]
        public ActionResult deletetraine(traineee t)
        {
            traineee x = db.traineees.Where(n => n.id == t.id).FirstOrDefault();
            db.traineees.Remove(x);
            db.SaveChanges();
            return RedirectToAction("traineee", "admin");
        }
        #endregion

    }


}
