using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TNT_express.Models;

namespace TNT_express.Controllers
{
    
    public class AdminController : Controller
    {
        tnt_data_model db = new tnt_data_model();
        // GET: Admin

        public ActionResult Index()
        {
            if ( Session["userid"].ToString() != null )
            {
                if( Session["U_role"].ToString() == "admin")
                {
                         return View();
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            else 
            {
                return RedirectToAction("Login", "Home");
            }
           
        }
        [HttpDelete]
        public ActionResult c_Delete(int id)
        {


            contact ucondel = db.contacts.Where(x => x.Id == id).FirstOrDefault();

            db.contacts.Remove(ucondel);
            db.SaveChanges();
            return View();
        }
        [HttpDelete]
        public ActionResult s_Delete(int id)
        {
            shedule sheduledel = db.shedules.Where(x => x.shedule_id == id).FirstOrDefault();

            db.shedules.Remove(sheduledel);
            db.SaveChanges();

            return View();
        }
        [HttpDelete]
        public ActionResult b_Delete(int id)
        {

            bus busdel = db.buses.Where(x => x.bus_id == id).FirstOrDefault();

            db.buses.Remove(busdel);
            db.SaveChanges();

            return View();
        }
        [HttpDelete]
        public ActionResult bl_Delete(int id)
        {
            blog blogdel = db.blogs.Where(x => x.Id == id).FirstOrDefault();

            db.blogs.Remove(blogdel);
            db.SaveChanges();

            return View();
        }
        [HttpDelete]
        public ActionResult t_Delete(int id)
        {

            ticket tickdel = db.tickets.Where(x => x.ticket_Id == id).FirstOrDefault();

            db.tickets.Remove(tickdel);
            db.SaveChanges();

            return View();
        }
        [HttpDelete]
        public ActionResult tt_Delete(int id)
        {


            terminl ttermnkdel = db.terminls.Where(x => x.Id == id).FirstOrDefault();

            db.terminls.Remove(ttermnkdel);
            db.SaveChanges();

            return View();
        }
        [HttpDelete]
        public ActionResult u_Delete(int id)
        {
            user userdel = db.users.Where(x => x.user_id == id).FirstOrDefault();
            if (userdel != null)
            {
                db.users.Remove(userdel);
                db.SaveChanges();

            }

            return View();
        }
        public ActionResult Users()
        {
            if (Session["U_role"].ToString() == "admin" && Session["userid"].ToString() != null)
            {
                return View(db.users.ToList());
            }
            else 
            {
                return RedirectToAction("Login", "Home");
            }
            
           
        }
        public ActionResult c_Users()
        {
            return View();
        }
        [HttpPost]
        public ActionResult c_Users(user obj, HttpPostedFileBase user_pic)
        {
            if (Session["U_role"].ToString() == "admin" && Session["userid"].ToString() != null)
            {
                if (ModelState.IsValid)
                {
                        user_pic.SaveAs(Server.MapPath("~/Assets/user_img/" + user_pic.FileName));
                        obj.u_img = user_pic.FileName;
                    
                    db.users.Add(obj);
                    db.SaveChanges();
                    return RedirectToAction("User", "Admin");
                }
                return View();



            }
            else 
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult e_Users(user obj)
        {
            if (Session["U_role"].ToString() == "admin" && Session["userid"].ToString() != null)
            {
                 if (ModelState.IsValid)
                {
                   
                    
                    db.users.Add(obj);
                    db.SaveChanges();
                    return RedirectToAction("User", "Admin");
                }
                return View();
            }
            else 
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult Bus()
        {
            if (Session["U_role"].ToString() == "admin" && Session["userid"].ToString() != null)
            {
                return View(db.buses.ToList());
            }
            else 
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult logout()
        {
            Session["userid"] = null;
            return RedirectToAction("Login", "Home");
        }
        public ActionResult c_Bus()
        {
            return View();
        }
        [HttpPost]
        public ActionResult c_Bus(bus obj)
        {
            if (Session["U_role"].ToString() == "admin" && Session["userid"].ToString() != null)
            {
                if (ModelState.IsValid)
                {
                    db.buses.Add(obj);
                    db.SaveChanges();
                    return RedirectToAction("Bus", "Admin");
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }
        public ActionResult e_Bus()
        {
            if (Session["U_role"].ToString() == "admin" && Session["userid"].ToString() != null)
            {
                return View();
            }
            else 
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult Shedule()
        {
            if (Session["U_role"].ToString() == "admin" && Session["userid"].ToString() != null)
            {
                return View(db.shedules.ToList());
            }
            else 
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult c_Shedule()
        {
            return View();
        }
        [HttpPost]
        public ActionResult c_Shedule(shedule obj)
        {
            if (Session["U_role"].ToString() == "admin" && Session["userid"].ToString() != null)
            {
                if (ModelState.IsValid)
                {
                    db.shedules.Add(obj);
                    db.SaveChanges();
                    return RedirectToAction("Shedule", "Admin");
                }
                return View();
            }
            else 
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult e_Shedule()
        {
            if (Session["U_role"].ToString() == "admin" && Session["userid"].ToString() != null)
            {
                return View();
            }
            else 
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult Ticket()
        {
            if (Session["U_role"].ToString() == "admin" && Session["userid"].ToString() != null)
            {
                return View(db.tickets.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
            
        }
        public ActionResult c_Ticket()
        {
            return View();
        }
        [HttpPost]
        public ActionResult c_Ticket(ticket obj)
        {
            if (Session["U_role"].ToString() == "admin" && Session["userid"].ToString() != null)
            {
                if (ModelState.IsValid)
                {
                    db.tickets.Add(obj);
                    db.SaveChanges();
                    return RedirectToAction("Shedule", "Admin");
                }
                return View();
            }
            else 
            {
                return RedirectToAction("Login", "Home");
            }

        }
        public ActionResult e_Ticket()
        {
            if (Session["U_role"].ToString() == "admin" && Session["userid"].ToString() != null)
            {
                return View();
            }
            else 
            {
                return RedirectToAction("Login", "Home");
            }

        }
        public ActionResult Blogs()
        {
            if (Session["U_role"].ToString() == "admin" && Session["userid"].ToString() != null)
            {
                return View(db.blogs.ToList());
            }
            else 
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult c_Blogs()
        {

            return View();
        }
        [HttpPost]
        public ActionResult c_Blogs(blog obj, HttpPostedFileBase blog_pic)
        {
            if (Session["U_role"].ToString() == "admin" && Session["userid"].ToString() != null)
            {
                if (ModelState.IsValid)
                    {
                    if (blog_pic.ContentLength > 0)
                    {
                        blog_pic.SaveAs(Server.MapPath("~/Assets/blogs/" + blog_pic.FileName));
                        obj.pic_blog = blog_pic.FileName;
                    }
                    else
                    {
                        ViewBag.msg = "please upload a img";
                    }
                    db.blogs.Add(obj);
                    db.SaveChanges();
                    }
                return RedirectToAction("blog", "Admin");
            }
            else 
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult e_Blogs()
        {
            if (Session["U_role"].ToString() == "admin" && Session["userid"].ToString() != null)
            {
                return View();
            }
            else 
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult Contact()
        {
            if (Session["U_role"].ToString() == "admin" && Session["userid"].ToString() != null)
            {
                return View(db.contacts.ToList());
            }
            else 
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult termnal()
        {
            if (Session["U_role"].ToString() == "admin" && Session["userid"].ToString() != null)
            {
                return View(db.terminls.ToList());
            }
            else 
            {
                return RedirectToAction("Login", "Home");
            }

        }
        public ActionResult c_termnal()
        {
            return View();
        }
        [HttpPost]
        public ActionResult c_termnal(terminl obj, HttpPostedFileBase terminl_pic)
        {
            if (Session["U_role"].ToString() == "admin" && Session["userid"].ToString() != null)
            {
                if (ModelState.IsValid)
                {
                    if (terminl_pic.ContentLength > 0)
                    {
                        terminl_pic.SaveAs(Server.MapPath("~/Assets/terminals/" + terminl_pic.FileName));
                        obj.pic_terminal = terminl_pic.FileName;
                    }
                    else
                    {
                        ViewBag.msg = "please upload a img";
                    }
                    db.terminls.Add(obj);
                    db.SaveChanges();
                    return RedirectToAction("termnal", "Admin");
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }
        public ActionResult e_termnal()
        {
            if (Session["U_role"].ToString() == "admin" && Session["userid"].ToString() != null)
            {
                return View();
            }
            else 
            {
                return RedirectToAction("Login", "Home");
            }
        }
    }
}