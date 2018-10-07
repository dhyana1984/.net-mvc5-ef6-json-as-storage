using MVCEF.JsonStorage.Enity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MVCEF.JsonStorage.EFDBContext
{
    public class EFDbContext : DbContext
    {
        public EFDbContext() : base("name=efConnectionStr")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes().Where(types => !string.IsNullOrEmpty(types.Namespace))
                               .Where(type => type.BaseType != null
                                      && type.BaseType.IsGenericType
                                      && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Blog> Blogs {get;set;}
        public DbSet<Post> Posts { get; set; }
          
    }
}