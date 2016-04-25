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
                
                RedirectToAction("Index", "BlogMaintenance");
            }
            
            return RedirectToAction("Index", "BlogMaintenance");

           // return View("Index");//RedirectToAction(nameof(Index));
            
        }


    }
}