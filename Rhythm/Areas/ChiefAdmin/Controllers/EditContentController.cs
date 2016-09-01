using AutoMapper;
using Rhythm.Areas.ChiefAdmin.Models;
using Rhythm.Domain.Abstract;
using Rhythm.Domain.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rhythm.Areas.ChiefAdmin.Controllers
{

    public class EditContentController : DefaultController
    {
        public EditContentController(IRepository repository)
        {
            this.repository = repository;
        }
        // GET: ChiefAdmin/AddContent

        public ActionResult Post()
        {
            CategoryDropDownList Categories = new CategoryDropDownList
            {
                Category = repository.Category
                    .OrderBy(c => c.ID)
                    .ToList()
            };

            TagDropDownList Tags = new TagDropDownList
            {
                Tag = repository.Tag
                .OrderBy(c => c.ID)
                .ToList()
            };

            ViewBag.Category = new SelectList(Categories.Category, "ID", "Name", 1);
            ViewBag.Tag = new SelectList(Tags.Tag, "ID", "Name", 1);
            return View();
        }

        [HttpPost]
        public ActionResult Post(PostViewModel post)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var recent = new ICollection<post.Tag>;

                    var tag = repository.Tag
                        .OrderBy(c => c.ID)
                        .ToList();

                    tag.ForEach(t => { var p = });
                    byte[] image = new byte[post.imageData.ContentLength];
                    post.imageData.InputStream.Read(image, 0, image.Length);

                    Post p = new Post
                    {
                        NameSenderPost = post.NameSenderPost,
                        Title = post.Title,
                        ShortDescription = post.ShortDescription,
                        DescriptionPost = post.DescriptionPost,
                        UrlSlug = post.UrlSlug,
                        Published = post.Published,
                        Category = post.Category,
                        Tags = post.Tag,
                        ImageData = image,
                        ImageMime = post.ImageMime,
                        
                    };

                    repository.AddPost(p);
                    var postID = repository.Post.FirstOrDefault(c => c.UrlSlug == post.UrlSlug);

                }
                catch (Exception)
                {

                }
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult EditTag()
        {

            return View();
        }

        [HttpPost]
        public ActionResult EditTag(TagViewModel tag)
        {

            return View();
        }

        public ActionResult EditCategory()
        {

            return View();
        }

        [HttpPost]
        public ActionResult EditCategory(CategoryViewModel category)
        {

            return View();
        }
    }
}