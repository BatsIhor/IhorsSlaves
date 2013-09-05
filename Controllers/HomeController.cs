using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IhorsSlaves.Models;
using IhorsSlaves.Context;
using IhorsSlaves.Repository;

namespace IhorsSlaves.Controllers
{
    public class HomeController : Controller
    {
        private IPostRepository repository;
        public HomeController(IPostRepository postRepository)
        {
            this.repository = postRepository;
        }

        int pageSize = 5;
        public ActionResult Index(int page = 1)
        {
            ViewBag.Message = "Раби работают!";
            ShowPostsOnPages model = new ShowPostsOnPages
            {
                Posts = repository.GetPosts().Skip((page - 1) * pageSize).Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = repository.GetPosts().Count()
                }
            };
            return View(model);
        }
        
        [Authorize]
        public ActionResult AddPost()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        [ValidateInput(false)]
        public ActionResult AddPost(Post post)
        {
            if (ModelState.IsValid)
            {
                repository.AddPost(post, User.Identity.Name, DateTime.Now);
                repository.SaveChanges();
                return RedirectToAction("Index");
            }
            else return View(post);
        }

        public ActionResult FullPost(int PostId = 0)
        {
            Post post = repository.FindPostById(PostId);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostUser = false; 
            if (User.Identity.Name == post.PostUser)
            {
                ViewBag.PostUser = true;
            }

            return View(post);
        }
        //Не працює
        [Authorize]
        public ActionResult EditPost(int PostId = 0)
        {

            Post post = repository.FindPostById(PostId);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }
        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditPost(Post post)
        {
            if (ModelState.IsValid)
            {
                repository.EditPost(post);
                repository.SaveChanges();
                return RedirectToAction("Index");
            }
            else return View(post);
        }


        [Authorize]
        public ActionResult DeletePost(int postId = 0)
        {
            Post post = repository.FindPostById(postId);
            if (User.Identity.Name == post.PostUser)
            {
                repository.DeletePost(post);
                repository.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}
