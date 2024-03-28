using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TNT_express.Models;

namespace TNT_express.Controllers
{
  
    public class EmployeeController : Controller
    {
        tnt_data_model db = new tnt_data_model();
        // GET: Employee
        public ActionResult Index()
        {
            if (Session["U_role"].ToString() == "employee" && Session["userid"].ToString() != null)
            {
                //try
                //{
                //    ViewBag.DataPoints = JsonConvert.SerializeObject(db.Points.ToList(), _jsonSetting);

                //    return View();
                //}
                //catch (System.Data.Entity.Core.EntityException)
                //{
                //    return View("Error");
                //}
                //catch (System.Data.SqlClient.SqlException)
                //{
                //    return View("Error");
                //}
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
        public ActionResult Contact()
        {
            if (Session["U_role"].ToString() == "employee" && Session["userid"].ToString() != null)
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
            if (Session["U_role"].ToString() == "employee" && Session["userid"].ToString() != null)
            {
                return View(db.terminls.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }
        public ActionResult Blogs()
        {
            if (Session["U_role"].ToString() == "employee" && Session["userid"].ToString() != null)
            {
                return View(db.blogs.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult Ticket()
        {
            if (Session["U_role"].ToString() == "employee" && Session["userid"].ToString() != null)
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
            if (Session["U_role"].ToString() == "employee" && Session["userid"].ToString() != null)
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
            if (Session["U_role"].ToString() == "employee" && Session["userid"].ToString() != null)
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
            if (Session["U_role"].ToString() == "employee" && Session["userid"].ToString() != null)
            {
                return View(db.shedules.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult Bus()
        {
            if (Session["U_role"].ToString() == "employee" && Session["userid"].ToString() != null)
            {
                return View(db.buses.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
    }
}