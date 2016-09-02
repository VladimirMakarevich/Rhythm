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


        public ICollection<PostTag> TagCollection(List<int> item)
        {
            var tagList = new List<PostTag>();

            foreach (var i in item)
            {
                var q = repository.Tag.FirstOrDefault(t => t.PostTags == null);
                var tt = repository.Post.FirstOrDefault(p => p.PostTags == null);

                tagList.Add();
            }
            //if (tags.Length > 0)
            //{
            //    post.Tags = new List<Tag>();

            //    foreach (var tag in tags)
            //    {
            //        post.Tags.Add(_blogRepository.Tag(int.Parse(tag.Trim())));
            //    }
            //}
            return tagList;
        }

        [HttpPost]
        public ActionResult Post(PostViewModel post)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var tagList = TagCollection(post.Tag);

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
                        ImageData = image,
                        ImageMime = post.ImageMime,
                        PostTags = 
                                         
                        
                    };

                    repository.AddPost(p);
                }
                catch (Exception ex)
                {
                    //TODO: NLog
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