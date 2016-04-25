using System;
using Microsoft.AspNet.Mvc;
using System.Linq;
using System.Collections.Generic;
using weblog.Models.Blog;
using weblog.ViewComponents;

namespace weblog.Controllers
{
    public class BlogMaintenanceController : Controller
    {
        private BlogDbContext _context;
        private List<Post> Posts;
        
        public BlogMaintenanceController(BlogDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            return View("Index");
        }
        
        public IActionResult NewPost()
        {
            return View();
        }
        
        public IActionResult EditPost(int? id)
        {
            Post post = _context.Posts.Single(p => p.PostId == id);
            
            if (post == null)
            {
                return HttpNotFound();
            }
            
            return View("NewPost", post);
        }

        /*public IActionResult Create()
        {
            return View("Index");//RedirectToAction(nameof(Index));
        }*/
        
        [HttpPost]
        public IActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                post.Status = Post.PostStatus.Draft;
                _context.Posts.Add(post);
                _context.SaveChanges();
                
                //RedirectToAction("Index", "BlogMaintenance");
            }
            
            return RedirectToAction("Index", "BlogMaintenance");

           // return View("Index");//RedirectToAction(nameof(Index));
            
        }
        
        public IActionResult SavePost(Post post)
        {
            if (ModelState.IsValid)
            {
                /*if (post.PostId == 0)
                {
                    _context.Posts.Add(post);
                    _context.SaveChanges();
                }
                else
                {*/
                    _context.Posts.Update(post);
                    _context.SaveChanges();
                //}
                
                //_context.
            }
            
            return RedirectToAction("EditPost", "BlogMaintenance", new {id = post.PostId});
        }


    }
}