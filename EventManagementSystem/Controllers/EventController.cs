using EventManagementSystem.Dbconnection;
using EventManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagementSystem.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        StudentDbEntities Db=new StudentDbEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(EventModel model) 
        {
            Event obj = new Event();
            obj.Name = model.Name;
            obj.StartTime = model.StartTime;
            obj.EndTime = model.EndTime;
            obj.Description = model.Description;
            obj.Notification = model.Notification;
            Db.Events.Add(obj);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetList()
        {
            var data= Db.Events.ToList();
            return View(data);
        }

        public ActionResult Read(int id)
        {
            var data=Db.Events.Find(id);
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var data=Db.Events.Where(m=>m.Id == id).FirstOrDefault();
            Db.Events.Remove(data);
            Db.SaveChanges();
            return RedirectToAction("GetList");
        }
    }
}