using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.JustBlog.Core.Models
{
    public class FAJustBlogUser : IdentityUser
    {
        public FAJustBlogUser()
        {
            Posts = new List<Post>();
            Comments = new List<Comment>();
        }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Firstname { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }


        public virtual IList<Post> Posts { get; set; }
        public virtual IList<Comment> Comments { get; set; }
    }
}
