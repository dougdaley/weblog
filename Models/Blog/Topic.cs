using System.Collections.Generic;

namespace weblog.Models.Blog
{
    public class Topic
    {
        public int TopicId { get; set; }
        public string Title { get; set; }
        public List<Post> Posts { get; set; }
    }
}