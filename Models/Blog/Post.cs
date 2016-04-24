using System;

namespace weblog.Models.Blog
{
    
    public class Post
    {
        enum PostStatus
        {
            Draft = 0,
            Published = 1
        };
        
        public int PostId { get; set; }
        public string Title { get; set; }
        public Topic Topic { get; set; }
        public string Content { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
    }
}