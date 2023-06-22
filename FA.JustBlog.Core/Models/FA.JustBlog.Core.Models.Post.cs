namespace FA.JustBlog.Core.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string? ShortDescripion { get; set; }

        public string PostContent { get; set; }

        public string UrlSlug { get; set; }

        public bool Published { get; set; }

        public DateTime PostedOn { get; set; }

        public DateTime Modified { get; set; }

        public int CategoryId { get; set; }
        public int ViewCount { get; set; }
        public int RateCount { get; set; }
        public int TotalRate { get; set; }

        private decimal rate;

        public decimal Rate
        {
            get { return rate; }
            set
            {
                rate = value;
                value = TotalRate / RateCount;
            }
        }


        public virtual Category Category { get; set; }

        public virtual ICollection<PostTagMap> PostTagMaps { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public string? FAJustBlogUserId { get; set; }
        public FAJustBlogUser FAJustBlogUser { get; set; }
    }
}
