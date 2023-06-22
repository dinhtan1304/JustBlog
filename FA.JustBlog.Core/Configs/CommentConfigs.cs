using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FA.JustBlog.Core.Configs
{
    public class CommentConfigs : IEntityTypeConfiguration<Comment>
    {
        /// <summary>
        /// dinh nghia cac thuoc tinh cua comment
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).IsRequired().HasMaxLength(255);
        }
    }
}
