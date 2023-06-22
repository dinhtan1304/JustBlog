using FA.JustBlog.Core.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Blog_Owner,CONTRIBUTOR")]
    public class CommentAdminController : Controller
    {
        public const int ITEMS_PER_PAGE = 5;

        private readonly IUnitOfWork unitOfWork;
        public CommentAdminController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: CommentController
        public ActionResult Index([Bind(Prefix = "page")] int pageNumber)
        {
            if (pageNumber == 0)
                pageNumber = 1;
            var cmt = unitOfWork.CommentRepositoty.GetAll();
            var totalItems = cmt.Count();
            int totalPages = (int)Math.Ceiling((double)totalItems / ITEMS_PER_PAGE);
            if (pageNumber > totalPages)
                return RedirectToAction(nameof(CommentAdminController.Index), new { page = totalPages });
            var cmts = cmt
                    .Skip(ITEMS_PER_PAGE * (pageNumber - 1))
                    .Take(ITEMS_PER_PAGE)
                    .ToList();
            ViewData["pageNumber"] = pageNumber;
            ViewData["totalPages"] = totalPages;
            return View(cmts.AsEnumerable());
        }
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                var post = unitOfWork.CommentRepositoty.Find(id.Value);
                if (post != null)
                {
                    return View(post);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: CommentController/Delete/5
        [Authorize(Roles = "Blog_Owner")]
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                unitOfWork.CommentRepositoty.Delete(id.Value);
                unitOfWork.SaveChange();
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
