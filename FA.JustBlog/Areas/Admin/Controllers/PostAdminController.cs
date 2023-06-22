using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.UnitOfWork;
using FA.JustBlog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Blog_Owner,CONTRIBUTOR")]
    public class PostAdminController : Controller
    {
        public const int ITEMS_PER_PAGE = 5;
        private readonly IUnitOfWork unitOfWork;
        public PostAdminController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: PostController
        public ActionResult IndexPost([Bind(Prefix = "page")] int pageNumber)
        {
            if (pageNumber == 0)
                pageNumber = 1;
            var post = unitOfWork.PostRepository.GetAll();
            var totalItems = post.Count();
            int totalPages = (int)Math.Ceiling((double)totalItems / ITEMS_PER_PAGE);
            if (pageNumber > totalPages)
                return RedirectToAction(nameof(PostAdminController.IndexPost), new { page = totalPages });
            var posts = post
                    .Skip(ITEMS_PER_PAGE * (pageNumber - 1))
                    .Take(ITEMS_PER_PAGE)
                    .ToList();
            ViewData["pageNumber"] = pageNumber;
            ViewData["totalPages"] = totalPages;
            return View(posts.AsEnumerable());
        }
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                var post = unitOfWork.PostRepository.Find(id.Value);
                if (post != null)
                {
                    return View(post);
                }
            }
            return RedirectToAction(nameof(IndexPost));
        }
        public ActionResult LatestPost([Bind(Prefix = "page")] int pageNumber)
        {
            if (pageNumber == 0)
                pageNumber = 1;
            var latestPost = unitOfWork.PostRepository.GetLatestPost(10);
            var totalItems = latestPost.Count();
            int totalPages = (int)Math.Ceiling((double)totalItems / ITEMS_PER_PAGE);
            if (pageNumber > totalPages)
                return RedirectToAction(nameof(PostAdminController.LatestPost), new { page = totalPages });
            var latestPosts = latestPost
                    .Skip(ITEMS_PER_PAGE * (pageNumber - 1))
                    .Take(ITEMS_PER_PAGE)
                    .ToList();
            ViewData["pageNumber"] = pageNumber;
            ViewData["totalPages"] = totalPages;
            return View(latestPosts.AsEnumerable());
        }
        public ActionResult MostViewedPost([Bind(Prefix = "page")] int pageNumber)
        {
            if (pageNumber == 0)
                pageNumber = 1;
            var mostPost = unitOfWork.PostRepository.GetMostViewedPost(10);
            var totalItems = mostPost.Count();
            int totalPages = (int)Math.Ceiling((double)totalItems / ITEMS_PER_PAGE);
            if (pageNumber > totalPages)
                return RedirectToAction(nameof(PostAdminController.MostViewedPost), new { page = totalPages });
            var mostPosts = mostPost
                    .Skip(ITEMS_PER_PAGE * (pageNumber - 1))
                    .Take(ITEMS_PER_PAGE)
                    .ToList();
            ViewData["pageNumber"] = pageNumber;
            ViewData["totalPages"] = totalPages;
            return View(mostPosts.AsEnumerable());
        }
        public ActionResult PublisedPost([Bind(Prefix = "page")] int pageNumber)
        {
            if (pageNumber == 0)
                pageNumber = 1;
            var pulisedPost = unitOfWork.PostRepository.GetPublisedPosts();
            var totalItems = pulisedPost.Count();
            int totalPages = (int)Math.Ceiling((double)totalItems / ITEMS_PER_PAGE);
            if (pageNumber > totalPages)
                return RedirectToAction(nameof(PostAdminController.PublisedPost), new { page = totalPages });
            var pulisedPosts = pulisedPost
                    .Skip(ITEMS_PER_PAGE * (pageNumber - 1))
                    .Take(ITEMS_PER_PAGE)
                    .ToList();
            ViewData["pageNumber"] = pageNumber;
            ViewData["totalPages"] = totalPages;
            return View(pulisedPosts.AsEnumerable());
        }
        public ActionResult UnpublisedPost([Bind(Prefix = "page")] int pageNumber)
        {
            if (pageNumber == 0)
                pageNumber = 1;
            var unPulisedPost = unitOfWork.PostRepository.GetPublisedPosts();
            var totalItems = unPulisedPost.Count();
            int totalPages = (int)Math.Ceiling((double)totalItems / ITEMS_PER_PAGE);
            if (pageNumber > totalPages)
                return RedirectToAction(nameof(PostAdminController.UnpublisedPost), new { page = totalPages });
            var unPulisedPosts = unPulisedPost
                    .Skip(ITEMS_PER_PAGE * (pageNumber - 1))
                    .Take(ITEMS_PER_PAGE)
                    .ToList();
            ViewData["pageNumber"] = pageNumber;
            ViewData["totalPages"] = totalPages;
            return View(unPulisedPosts.AsEnumerable());
        }
        public ActionResult Create()
        {
            var cate = unitOfWork.CategoryRepository.GetAll();
            ViewData["categories"] = new SelectList(cate, "Id", "Name");
            return View();
        }
        public static string Slugify(string str)
        {
            str = str.ToLower().Trim();
            str = Regex.Replace(str, @"[^a-z0-9 -]", "");
            str = Regex.Replace(str, @"\s+", "-");
            return str;
        }
        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Blog_Owner,CONTRIBUTOR")]
        public ActionResult Create(PostViewModel post, int[] PostTagMaps)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newPost = new Post { Title = post.Title, ShortDescripion = post.ShortDescripion, PostContent = post.PostContent, UrlSlug = Slugify(post.Title), Published = post.Published, PostedOn = DateTime.Now, Modified = DateTime.Now, CategoryId = post.CategoryId, FAJustBlogUserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) };
                    unitOfWork.PostRepository.Create(newPost);
                    unitOfWork.SaveChange();
                    foreach (int tagId in PostTagMaps)
                    {
                        unitOfWork.PostTagMaps.Create(new PostTagMap { PostId = newPost.Id, TagId = tagId });
                    }
                    unitOfWork.SaveChange();
                    return RedirectToAction(nameof(IndexPost));
                }
            }
            catch
            {
                return View();
            }
            return View(post);
        }
        [Authorize(Roles = "Blog_Owner,CONTRIBUTOR")]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var post = unitOfWork.PostRepository.Find(id.Value);
                if (post != null)
                {
                    var cate = unitOfWork.CategoryRepository.GetAll();
                    ViewBag.PostOn = post.PostedOn;
                    ViewData["categories"] = new SelectList(cate, "Id", "Name");
                    return View(post);
                }
            }
            return RedirectToAction(nameof(Index));
        }



        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Blog_Owner,CONTRIBUTOR")]
        public ActionResult Edit(int? id, PostViewModel post, int[] PostTagMaps)
        {
            if (id != post.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    if (id.HasValue)
                    {
                        unitOfWork.PostRepository.Update(new Post()
                        {
                            Id = post.Id,
                            Title = post.Title,
                            ShortDescripion = post.ShortDescripion,
                            PostContent = post.PostContent,
                            UrlSlug = Slugify(post.Title),
                            Published = post.Published,
                            Modified = DateTime.Now,
                            CategoryId = post.CategoryId,
                            FAJustBlogUserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)
                        });
                        unitOfWork.SaveChange();
                        foreach (int tagId in PostTagMaps)
                        {
                            unitOfWork.PostTagMaps.Create(new PostTagMap { PostId = post.Id, TagId = tagId });
                        }
                        unitOfWork.SaveChange();
                    }
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                return RedirectToAction(nameof(IndexPost));
            }
            return View(post);
        }
        // GET: PostController/Delete/5
        [Authorize(Roles = "Blog_Owner")]
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                unitOfWork.PostRepository.Delete(id.Value);
                unitOfWork.SaveChange();
            }
            return RedirectToAction(nameof(IndexPost));
        }

    }
}
