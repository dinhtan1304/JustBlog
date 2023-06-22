using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FA.JustBlog.Core.Configs
{
    public class PostTagMapConfigs : IEntityTypeConfiguration<PostTagMap>
    {
        /// <summary>
        /// dinh nghia thuoc tinh cua posttagmap
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<PostTagMap> builder)
        {
            builder.HasKey(ptm => new { ptm.PostId, ptm.TagId });

            //builder.HasOne<Post>(ptm => ptm.Post).WithMany(p => p.PostTagMaps).HasForeignKey(p => p.PostId);

            //builder.HasOne<Tag>(ptm => ptm.Tag).WithMany(t => t.PostTagMaps).HasForeignKey(t => t.TagId);
        }
    }
}
