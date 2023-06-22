using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string? ShortDescripion { get; set; }

        public string PostContent { get; set; }

        public string? UrlSlug { get; set; }

        public bool Published { get; set; }

        public DateTime? PostedOn { get; set; }

        public DateTime? Modified { get; set; }

        public int CategoryId { get; set; }

        public string? FAJustBlogUserId { get; set; }

        public virtual ICollection<PostTagMap>? PostTagMaps { get; set; }
    }
}
