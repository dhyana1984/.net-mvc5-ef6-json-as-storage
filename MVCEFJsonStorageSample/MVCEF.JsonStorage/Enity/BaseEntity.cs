using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEF.JsonStorage.Enity
{
    public class BaseEntity
    {
      
        public int Id { set; get; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifiedTime { get; set; }

        public BaseEntity()
        {
            ModifiedTime = DateTime.Now;
            CreateTime = DateTime.Now;
        }
    }
}