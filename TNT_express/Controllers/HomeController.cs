using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TNT_express.Models;

namespace TNT_express.Controllers
{
    
    public class HomeController : Controller
    {
        tnt_data_model db = new tnt_data_model();
        public ActionResult blog()
        {
            return View(db.blogs.ToList());
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult bus_res(string hiddenobj)
        {
            
            return View();
        }
        public ActionResult bus_res()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string departure, string destination, DateTime datefield)
        {
            if (Session["userid"] != null)
            {
                var shedule = db.shedules.Where(x => x.departure == departure && x.destination == destination && x.travel_date == datefield).FirstOrDefault();
                if (shedule != null)
                {
                    Session["shed_id"] = shedule.shedule_id;
                    Session["bus_id"] = shedule.bus_id;
                    Session["fare"] = shedule.Fare;
                    return RedirectToAction("shedule", "Home", shedule);
                }
                else
                {
                    Response.Write("<script>alert('First you have to register!')</script>");
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                Response.Write("<script>alert('First you have to register!')</script>");
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult shedule()
        {
            return View(db.shedules.ToList());
        }
       
        public ActionResult Forgetpassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Forgetpassword(string email,string number,string password)
        {
            var user = db.users.Where(x => x.u_email == email && x.u_phone == number).FirstOrDefault();
            if (user != null)
            {
                Session["userid"] = user.user_id;
                user.u_password = password;
                db.SaveChanges();

                if (user.u_role == "admin")
                {
                    return RedirectToAction("Index", "Admin", user);
                }
                else if (user.u_role == "employee")
                {
                    return RedirectToAction("Index", "Employee", user);
                }
                else
                {
                    return RedirectToAction("Index", "Home", user);
                }
            }
            else
            {
                ViewBag.msg = "Invalid information";
            }
            return View();
        }
        public ActionResult logout()
        {
            Session["userid"] = null;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(string username,string password)
        {
            var user = db.users.Where(x => x.u_name == username && x.u_password == password).FirstOrDefault();
            if(user != null)
            {
                Session["userid"] = user.user_id;
                Session["U_PROFILE"] = user.u_img;
                Session["u_name"] = user.u_name;
                Session["U_email"] = user.u_email;
                Session["U_role"] = user.u_role;

                if (user.u_role=="admin")
                {
                    return RedirectToAction("Index", "Admin", user);
                }
                else if (user.u_role == "employee")
                {
                    return RedirectToAction("Index", "Employee", user);
                }
                else
                {
                    return RedirectToAction("Index", "Home", user);
                }
            }
            else
            {
                ViewBag.msg = "Invalid information";
            }
            return View();
        }
        public ActionResult t_enquiry()
        {
            return View();
        }
        public ActionResult terminal()
        {
            return View(db.terminls.ToList());
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(user obj, HttpPostedFileBase user_pic)
        {
            if (ModelState.IsValid)
            {
                if (user_pic != null)
                {
                     user_pic.SaveAs(Server.MapPath("~/Assets/user_img/" + user_pic.FileName));
                obj.u_img = user_pic.FileName;
                }
                else
                {
                    obj.u_img = "null.jpg";
                }
               
                obj.u_role = "user";
                db.users.Add(obj);
                db.SaveChanges();
                Session["userid"] = obj.user_id;
                Session["U_PROFILE"] = obj.u_img;
                Session["u_name"] = obj.u_name;
                Session["U_email"] = obj.u_email;
                Session["U_role"] = obj.u_role;
                return RedirectToAction("Index","Home",obj);
            }
            else
            {
                ViewBag.msg = "Invalid information";
            }
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        [HttpPost]
        public ActionResult news(string mailed)
        {

            var senderemail = new EmailAddress("tendtexpress@gmail.com", "Admin");
            var recveremail = new EmailAddress(mailed,"Dear");
            var pass = "05547855";
            var sub = "Dear ";
            var msg = "Thanks for subscribe our website for more updates";

            var smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(senderemail.Email, pass);
            smtp.EnableSsl = true;
            var mssg = new MailMessage(senderemail.Email, recveremail.Email);
            mssg.Subject = sub;
            mssg.Body = msg;
            smtp.Send(mssg);
            return RedirectToAction("Index", "Home");
        }
        
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(contact obj)
        {
            var senderemail = new EmailAddress("tendtexpress@gmail.com","Admin");
            var recveremail = new EmailAddress(obj.c_email, obj.c_name);
            var pass = "05547855";
            var sub = "dear "+obj.c_name;
            var msg = "Your message has recieved";

            var smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(senderemail.Email, pass);
            smtp.EnableSsl = true;
            var mssg = new MailMessage(senderemail.Email, recveremail.Email);
            mssg.Subject = sub;
            mssg.Body = msg;
            smtp.Send(mssg);

            db.contacts.Add(obj);
            db.SaveChanges();
            return View();
        }
    }

}