using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FA.JustBlog.Core.Configs
{
    public class TagConfigs : IEntityTypeConfiguration<Tag>
    {
        /// <summary>
        /// dinh nghia thuoc tinh cua tag
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tag");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name).IsRequired().HasMaxLength(255);
        }
    }
}
