using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.UnitOfWork;
using FA.JustBlog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Blog_Owner,CONTRIBUTOR")]
    public class TagAdminController : Controller
    {
        public const int ITEMS_PER_PAGE = 5;

        private readonly IUnitOfWork unitOfWork;
        public TagAdminController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: TagController
        public ActionResult Index([Bind(Prefix = "page")] int pageNumber)
        {
            if (pageNumber == 0)
                pageNumber = 1;
            var tag = unitOfWork.TagRepository.GetAll();
            var totalItems = tag.Count();
            int totalPages = (int)Math.Ceiling((double)totalItems / ITEMS_PER_PAGE);
            if (pageNumber > totalPages)
                return RedirectToAction(nameof(TagAdminController.Index), new { page = totalPages });
            var tags = tag
                    .Skip(ITEMS_PER_PAGE * (pageNumber - 1))
                    .Take(ITEMS_PER_PAGE)
                    .ToList();
            ViewData["pageNumber"] = pageNumber;
            ViewData["totalPages"] = totalPages;
            return View(tags.AsEnumerable());
        }
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                var post = unitOfWork.TagRepository.Find(id.Value);
                if (post != null)
                {
                    return View(post);
                }
            }
            return RedirectToAction(nameof(Index));
        }
        // GET: TagController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TagController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TagViewModel tag)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.TagRepository.Create(new Tag() { Name = tag.Name, UrlSlug = tag.Name, Description = tag.Description, Count = tag.Count });
                    unitOfWork.SaveChange();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
            return View(tag);
        }

        // GET: TagController/Edit/5
        [Authorize(Roles = "Blog_Owner,CONTRIBUTOR")]

        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var tag = unitOfWork.TagRepository.Find(id.Value);
                if (tag != null)
                {
                    return View(tag);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: TagController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Blog_Owner,CONTRIBUTOR")]

        public IActionResult Edit(int? id, TagViewModel tag)
        {
            if (id != tag.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    if (id.HasValue)
                    {
                        unitOfWork.TagRepository.Update(new Tag() { Id = tag.Id, Name = tag.Name, UrlSlug = tag.Name, Description = tag.Description, Count = tag.Count });
                        unitOfWork.SaveChange();
                    }
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tag);

        }

        // GET: TagController/Delete/5
        [Authorize(Roles = "Blog_Owner")]
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                unitOfWork.TagRepository.Delete(id.Value);
                unitOfWork.SaveChange();
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
