using MVCEF.JsonStorage.Enity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MVCEF.JsonStorage.EntityMap
{
    public class BlogMap:EntityTypeConfiguration<Blog>
    {
        public BlogMap()
        {
            ToTable("Blogs");
            HasKey(t => t.Id);
            Property(t => t.Url).IsRequired().HasColumnType("varchar").HasMaxLength(100);
            Property(t => t._Tags).HasColumnName("Tags");
            Property(t => t._Owner).HasColumnName("Owner");

            //忽略属性
            Ignore(t => t.Owner);
            Ignore(t => t.Tags);

            HasMany(t => t.Posts).WithRequired(t => t.Blog).HasForeignKey(t => t.BlogId).WillCascadeOnDelete(true);

        }
    }
}