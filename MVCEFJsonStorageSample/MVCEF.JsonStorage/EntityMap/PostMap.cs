using MVCEF.JsonStorage.Enity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MVCEF.JsonStorage.EntityMap
{
    public class PostMap:EntityTypeConfiguration<Post>
    {
        public PostMap()
        {
            ToTable("Posts");

            HasKey(t => t.Id);

            Property(t => t.Title).IsRequired().HasColumnType("varchar").HasMaxLength(50);
            Property(t => t.Content);
        }
    }
}