using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Controllers
{
    public class PostController : Controller
    {
        public const int ITEMS_PER_PAGE = 5;
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<FAJustBlogUser> _userManager;
        public PostController(IUnitOfWork unitOfWork, UserManager<FAJustBlogUser> userManager)
        {
            this.unitOfWork = unitOfWork;
            this._userManager = userManager;
        }
        public ActionResult Index([Bind(Prefix = "page")] int pageNumber)
        {
            if (pageNumber == 0)
                pageNumber = 1;
            var result = unitOfWork.PostRepository.GetAll();
            var totalItems = result.Count();
            int totalPages = (int)Math.Ceiling((double)totalItems / ITEMS_PER_PAGE);
            if (pageNumber > totalPages)
                return RedirectToAction("Index", "Post", new { page = totalPages });
            var posts = result
                    .Skip(ITEMS_PER_PAGE * (pageNumber - 1))
                    .Take(ITEMS_PER_PAGE)
                    .ToList();
            ViewData["pageNumber"] = pageNumber;
            ViewData["totalPages"] = totalPages;
            return View(posts.AsEnumerable());
        }
        public IActionResult Detail(int year, int month, string title)
        {

            Post post = unitOfWork.PostRepository.FindPost(year, month, title);

            if (post != null)
            {
                post.Comments = unitOfWork.CommentRepositoty.GetCommentsForPost(post);
                return View(post);
            }
            ViewBag.IsComment = true;
            return RedirectToAction("Index");
        }

        public IActionResult GetPostByTag(string tag, [Bind(Prefix = "page")] int pageNumber)
        {
            if (pageNumber == 0)
                pageNumber = 1;
            var posts = unitOfWork.PostRepository.GetPostsByTag(tag);
            TempData["tagName"] = tag;
            var totalItems = posts.Count();
            int totalPages = (int)Math.Ceiling((double)totalItems / ITEMS_PER_PAGE);
            if (pageNumber > totalPages)
                return RedirectToAction("GetPostByTag", "Post", new { page = totalPages });
            var postsTag = posts
                    .Skip(ITEMS_PER_PAGE * (pageNumber - 1))
                    .Take(ITEMS_PER_PAGE)
                    .ToList();
            ViewData["pageNumber"] = pageNumber;
            ViewData["totalPages"] = totalPages;
            if (postsTag != null)
            {
                return View(postsTag.AsEnumerable());
            }
            return RedirectToAction("Index");
        }

        public IActionResult GetPostByCategory(string category, [Bind(Prefix = "page")] int pageNumber)
        {
            if (pageNumber == 0)
                pageNumber = 1;
            var posts = unitOfWork.PostRepository.GetPostsByCategory(category);
            TempData["categoryName"] = category;
            var totalItems = posts.Count();
            int totalPages = (int)Math.Ceiling((double)totalItems / ITEMS_PER_PAGE);
            if (pageNumber > totalPages)
                return RedirectToAction("GetPostByCategory", "Post", new { page = totalPages });
            var postsCategory = posts
                    .Skip(ITEMS_PER_PAGE * (pageNumber - 1))
                    .Take(ITEMS_PER_PAGE)
                    .ToList();
            ViewData["pageNumber"] = pageNumber;
            ViewData["totalPages"] = totalPages;
            if (postsCategory != null)
            {
                return View(postsCategory.AsEnumerable());
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CommentPost(int id, Comment comment)
        {
            var user = await _userManager.GetUserAsync(User);
            var post = unitOfWork.PostRepository.Find(id);
            if (User.Identity?.IsAuthenticated ?? false)
            {
                var postcmt = new Comment
                {
                    Name = user.Firstname + user.LastName,
                    CommentHeader = comment.CommentHeader,
                    PostId = id,
                    CommentText = comment.CommentText,
                    Email = User.Identity.Name,
                    CommentTime = DateTime.Now
                };
                unitOfWork.CommentRepositoty.Create(postcmt);
            }
            else
            {
                var postcmtuser = new Comment
                {
                    Name = comment.Name,
                    CommentHeader = comment.CommentHeader,
                    PostId = id,
                    CommentText = comment.CommentText,
                    Email = comment.Email,
                    CommentTime = DateTime.Now
                };
                unitOfWork.CommentRepositoty.Create(postcmtuser);
            }

            unitOfWork.SaveChange();
            return RedirectToAction("Detail", "Post", new
            {
                year = post.Modified.Year,
                month = post.Modified.Month,
                title = post.UrlSlug
            });
        }
    }
}
