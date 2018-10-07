using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVCEF.JsonStorage.Enity
{
    
    public class Post:BaseEntity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

      
        public int BlogId { get; set; }

        public virtual Blog Blog { get; set; }

    }
}