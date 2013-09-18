using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using IhorsSlaves.Models;
using IhorsSlaves.Context;
using IhorsSlaves.Repository;

namespace IhorsSlaves.Controllers
{
    public class AlbumController : Controller
    {
        private IPostRepository repository;

        public AlbumController(IPostRepository postRepository)
        {
            repository = postRepository;
        }

        private IhorsSlaversDbContext db = new IhorsSlaversDbContext();

        public ActionResult Index()
        {
            return View(db.ImagesAlbum.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            ImagesAlbum imagesalbum = db.ImagesAlbum.Find(id);
            if (imagesalbum == null)
            {
                return HttpNotFound();
            }
            return View(imagesalbum);
        }

        public ActionResult Create()
        {
            return View();
        }

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

        [HttpPost]
        [Authorize]
        [ValidateInput(false)]
        public ActionResult AddImage(Image image)
        {
            if (User.Identity.IsAuthenticated)
            {
                image.User = User.Identity.Name;
            }
            image.UploadDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                repository.AddImage(image);
                repository.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id = 0)
        {
            ImagesAlbum imagesalbum = db.ImagesAlbum.Find(id);
            if (imagesalbum == null)
            {
                return HttpNotFound();
            }
            return View(imagesalbum);
        }

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

        public ActionResult Delete(int id = 0)
        {
            ImagesAlbum imagesalbum = db.ImagesAlbum.Find(id);
            if (imagesalbum == null)
            {
                return HttpNotFound();
            }
            return View(imagesalbum);
        }

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