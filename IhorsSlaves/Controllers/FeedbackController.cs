using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IhorsSlaves.Models;
using IhorsSlaves.Context;

namespace IhorsSlaves.Controllers
{
    public class FeedbackController : Controller
    {
        private IhorsSlaversDbContext db = new IhorsSlaversDbContext();

        //
        // GET: /Feedback/
        [Authorize(Roles="admin")]
        public ActionResult Index()
        {
            return View(db.Feedbacks.ToList());
        }

        //
        // GET: /Feedback/Details/5
        [Authorize(Roles = "admin")]
        public ActionResult Details(int id = 0)
        {
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        //
        // GET: /Feedback/Create

        /*public ActionResult Create()
        {
            return View();
        }*/

        //
        // POST: /Feedback/Create

        [HttpPost]
        public ActionResult Create(Feedback feedback)
        {
            feedback.Date = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Feedbacks.Add(feedback);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(feedback);
        }


        //
        // GET: /Feedback/Edit/5

        /*public ActionResult Edit(int id = 0)
        {
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }*/

        //
        // POST: /Feedback/Edit/5
        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(feedback);
        }*/

        //
        // GET: /Feedback/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id = 0)
        {
            Feedback feedback = db.Feedbacks.Find(id);
            db.Feedbacks.Remove(feedback);
            db.SaveChanges();
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }

        //
        // POST: /Feedback/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Feedback feedback = db.Feedbacks.Find(id);
            db.Feedbacks.Remove(feedback);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}