using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCEF.JsonStorage.Enity
{
    public class Blog:BaseEntity
    {
        [Required,StringLength(100,ErrorMessage ="字数不能超过100个字符"),Url]
        public string Url { get; set; }


        public string Title { get; set; }

        internal string _Tags { get; set; }
        public string[] Tags
        {
            get { return _Tags == null ? null : JsonConvert.DeserializeObject<string[]>(_Tags); }
            set { _Tags = JsonConvert.SerializeObject(value); }
        }
        internal string _Owner { get; set; }

        public Person Owner
        {
            get { return (_Owner == null) ? null : JsonConvert.DeserializeObject<Person>(_Owner); }
            set { _Owner = JsonConvert.SerializeObject(value); }
        }

        public virtual ICollection<Post> Posts { get; set; }


    }
}