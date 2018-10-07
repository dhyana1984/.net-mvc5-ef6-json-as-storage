using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVCEF.JsonStorage.Enity
{
    public class Person
    {
        [DisplayName("中文姓名")]
        public string Name { get; set; }
        [DisplayName("英文名")]
        public string EglishName { get; set; }
        [DisplayName("邮箱")]
        public string Email { get; set; }

    }
}