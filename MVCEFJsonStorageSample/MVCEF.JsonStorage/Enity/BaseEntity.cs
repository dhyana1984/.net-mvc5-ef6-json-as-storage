using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCEF.JsonStorage.Enity
{
    public class BaseEntity
    {
        public int Id { set; get; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifiedTime { get; set; }

        public BaseEntity()
        {
            // CreateTime = DateTime.Now;
            ModifiedTime = DateTime.Now;
        }
    }
}