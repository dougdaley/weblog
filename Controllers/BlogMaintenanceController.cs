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
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Posts.Add(post);
                _context.SaveChanges();
            }

            return Index();
            //return CreatedAtActionResult(
        }


    }
}