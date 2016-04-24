using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using weblog.Models.Blog;

namespace weblog.ViewComponents
{
    public class DraftPostsViewComponent : ViewComponent
    {
        private BlogDbContext _context;
        
        public DraftPostsViewComponent(BlogDbContext context)
        {
            _context = context;
        }
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var drafts = await GetDraftsAsync();
            return View(drafts);
        }
        
        private Task<List<Post>> GetDraftsAsync()
        {
            return _context.Posts.Where(d => d.Status == Post.PostStatus.Draft).ToListAsync();
        }
        
    }
}