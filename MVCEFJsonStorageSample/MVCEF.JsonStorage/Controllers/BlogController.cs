using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MVCEF.JsonStorage.EFDBContext;
using MVCEF.JsonStorage.Enity;
using Newtonsoft.Json;

namespace MVCEF.JsonStorage.Controllers
{
    public class BlogController : Controller
    {
        

    
        public ActionResult Index()
        {
            var blogs = new List<Blog>();
            using (var _context = new EFDbContext())
            {
                blogs = _context.Blogs.AsNoTracking().ToList();
            }
            return View(blogs);
        }

        public ActionResult Search(string Owner)
        {
            var blogs = new List<Blog>();
            using (var _context = new EFDbContext())
            {
                blogs = _context.Blogs.ToList();
                blogs.All(t =>
                {
                    t.Owner = Transfer(t._Owner);
                    return true;
                });
            };
            if(!string.IsNullOrEmpty(Owner))
            {
                blogs = blogs.Where(t => t.Owner.Name == Owner || t.Owner.EglishName == Owner).ToList();
            }

            return View("Index", blogs);
        }



        
        public async Task<ActionResult> Get(int? id)
        {
            if (ReferenceEquals(id,null) || id.Value<=0)
            {
                return Content("<script type='text/javascript'>alert('提交参数不正确');location.href='/';</script>");
            }
            using (var _content = new EFDbContext())
            {
                var blog = await _content.Blogs.FindAsync(id);
                if(ReferenceEquals(blog,null))
                {
                    return Content("<script type='text/javascript'>alert('该博客不存在');location.href='/';</script>");

                }
                return View("UpInsert",blog);
            }
    
        
        }

        public ActionResult UpInsert()
        {
            return View();
        }

  

   
      
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpInsert(Blog blog)
        {
            
            if (ModelState.IsValid)
            {
                using (var _context =new  EFDbContext())
                {
                    if (blog.Id <= 0)
                    {
                        _context.Blogs.Add(blog);
                        blog.CreateTime = DateTime.Now;
                        blog.ModifiedTime = DateTime.Now;
                    }
                    else
                    {
                        var dbBlog = await _context.Blogs.FindAsync(blog.Id);
                        if (ReferenceEquals(blog, null))
                        {
                            return Content("<script type='text/javascript'>alert('提交参数不正确');location.href='/';</script>");
                        }
                        else
                        {
                            dbBlog.Owner = blog.Owner;
                            dbBlog.Tags = blog.Tags;
                            dbBlog.Url = blog.Url;
                            dbBlog.ModifiedTime = DateTime.Now;
                        }
                    }
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

   
        public async Task<ActionResult> Delete(int? id)
        {
            if (ReferenceEquals(id, null) || id.Value <= 0)
            {
                return Content("<script type='text/javascript'>alert('提交参数不正确');location.href='/';</script>");
            }
            using (var _content = new EFDbContext())
            {
                var dbblog = await _content.Blogs.FindAsync(id);
                if (ReferenceEquals(dbblog, null))
                {
                    return Content("<script type='text/javascript'>alert('该博客不存在');location.href='/';</script>");

                }
                else
                {
                    _content.Blogs.Remove(dbblog);
                    var result = _content.SaveChanges();
                    if(result>0)
                    {
                        return View("Index");
                    }
                    return Content("<script type='text/javascript'>alert('删除失败！');location.href='/';</script>");
                }
               
            }
        }

     

        Person Transfer(string p)
        {
            return JsonConvert.DeserializeObject<Person>(p);
        }
    }
}
