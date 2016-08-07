using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rhythm.Domain.Model;
using Rhythm.Domain.Abstract;

namespace Rhythm.Controllers
{
    public class PostsController : Controller
    {
        private IRepository repository;
        public PostsController(IRepository postRepository)
        {
            this.repository = postRepository;
        }

        // GET: Posts
        public ActionResult Index()
        {
            var post = repository.Posts.Include(p => p.Category1);
            return View(post.ToList());
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = repository.Posts.FirstOrDefault(p => p.ID == id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        //// GET: Posts/Create
        //public ActionResult Create()
        //{
        //    ViewBag.Category = new SelectList(repository.Categories, "ID", "Name");
        //    return View();
        //}

        //// POST: Posts/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,Title,ShortDescription,DescriptionPost,Meta,UrlSlug,Published,PostedOn,Modified,Category,Comment")] Post post)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        repository.Posts.Add(post);
        //        repository.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.Category = new SelectList(repository.Categories, "ID", "Name", post.Category);
        //    return View(post);
        //}

        //// GET: Posts/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Post post = repository.Posts.Find(id);
        //    if (post == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.Category = new SelectList(repository.Categories, "ID", "Name", post.Category);
        //    return View(post);
        //}

        //// POST: Posts/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,Title,ShortDescription,DescriptionPost,Meta,UrlSlug,Published,PostedOn,Modified,Category,Comment")] Post post)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        repository.Entry(post).State = EntityState.Modified;
        //        repository.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.Category = new SelectList(repository.Categories, "ID", "Name", post.Category);
        //    return View(post);
        //}

        //// GET: Posts/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Post post = repository.Posts.Find(id);
        //    if (post == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(post);
        //}

        //// POST: Posts/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Post post = repository.Post.Find(id);
        //    repository.Posts.Remove(post);
        //    repository.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        repository.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
