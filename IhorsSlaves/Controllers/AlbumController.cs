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
    public class AlbumController : Controller
    {
        private IhorsSlaversDbContext db = new IhorsSlaversDbContext();

        //
        // GET: /Album/

        public ActionResult Index()
        {
            return View(db.ImagesAlbum.ToList());
        }

        //
        // GET: /Album/Details/5

        public ActionResult Details(int id = 0)
        {
            ImagesAlbum imagesalbum = db.ImagesAlbum.Find(id);
            if (imagesalbum == null)
            {
                return HttpNotFound();
            }
            return View(imagesalbum);
        }

        //
        // GET: /Album/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Album/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ImagesAlbum imagesalbum)
        {
            if (ModelState.IsValid)
            {
                db.ImagesAlbum.Add(imagesalbum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(imagesalbum);
        }

        //
        // GET: /Album/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ImagesAlbum imagesalbum = db.ImagesAlbum.Find(id);
            if (imagesalbum == null)
            {
                return HttpNotFound();
            }
            return View(imagesalbum);
        }

        //
        // POST: /Album/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ImagesAlbum imagesalbum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imagesalbum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(imagesalbum);
        }

        //
        // GET: /Album/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ImagesAlbum imagesalbum = db.ImagesAlbum.Find(id);
            if (imagesalbum == null)
            {
                return HttpNotFound();
            }
            return View(imagesalbum);
        }

        //
        // POST: /Album/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImagesAlbum imagesalbum = db.ImagesAlbum.Find(id);
            db.ImagesAlbum.Remove(imagesalbum);
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