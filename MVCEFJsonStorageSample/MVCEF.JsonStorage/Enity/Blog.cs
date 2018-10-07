using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCEF.JsonStorage.Enity
{
    public class Blog:BaseEntity
    {
        [Required,StringLength(100,ErrorMessage ="字数不能超过100个字符"),DisplayName("博客地址")]
        public string Url { get; set; }


        public string Title { get; set; }

        internal string _Tags { get; set; }
        [DisplayName("技术标签")]
        public string[] Tags
        {
            get { return _Tags == null ? null : JsonConvert.DeserializeObject<string[]>(_Tags); }
            set { _Tags = JsonConvert.SerializeObject(value); }
        }
        internal string _Owner { get; set; }
        [DisplayName("博主名称")]
        public Person Owner
        {
            get { return (_Owner == null) ? null : JsonConvert.DeserializeObject<Person>(_Owner); }
            set { _Owner = JsonConvert.SerializeObject(value); }
        }

        public virtual ICollection<Post> Posts { get; set; }


    }
}