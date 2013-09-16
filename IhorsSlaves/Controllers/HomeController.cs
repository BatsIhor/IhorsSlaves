using System;
using System.Linq;
using System.Web.Mvc;
using IhorsSlaves.Models;
using IhorsSlaves.Repository;

namespace IhorsSlaves.Controllers
{
    public class HomeController : Controller
    {
        private IPostRepository repository;

        public HomeController(IPostRepository postRepository)
        {
            repository = postRepository;
        }

        int pageSize = 5;
        public ActionResult Index(int page = 1)
        {
            ViewBag.Message = "Сторінка";

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
            return View(post);
        }

        public ActionResult FullPost(int postId)
        {
            Post post = repository.FindPostById(postId);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostUser = false;
            if (User.Identity.Name == post.PostUser)
            {
                ViewBag.PostUser = true;
            }
            ViewPostModel vp = new ViewPostModel();
            vp.Post = post;
            return View(vp);
        }

        //Не працює
        [Authorize]
        public ActionResult EditPost(int postId = 0)
        {
            Post post = repository.FindPostById(postId);
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
            //TODO check for user role and allow to edit post only the same user or admin.
            if (ModelState.IsValid)
            {
                repository.EditPost(post);
                repository.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
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

        [ValidateInput(false)]
        public ActionResult AddComment(ViewPostModel vpm)
        {
            if (User.Identity.IsAuthenticated)
            {
                vpm.Comment.Email = "RegisteredUser@" + User.Identity.Name + ".com";
                vpm.Comment.User = User.Identity.Name;
            }
            vpm.Comment.Date = DateTime.Now;

            if (ModelState.IsValid)
            {
                repository.AddComment(vpm.Comment);
                repository.SaveChanges();
            }
            return RedirectToAction("FullPost", new { vpm.Comment.PostId });
        }
    }
}
