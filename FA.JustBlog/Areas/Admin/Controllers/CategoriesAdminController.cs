using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.UnitOfWork;
using FA.JustBlog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Blog_Owner,CONTRIBUTOR")]

    public class CategoriesAdminController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public CategoriesAdminController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public const int ITEMS_PER_PAGE = 5;
        // GET: Admin/Categories
        [Authorize]
        public ActionResult IndexCate([Bind(Prefix = "page")] int pageNumber)
        {
            if (pageNumber == 0)
                pageNumber = 1;
            var category = unitOfWork.CategoryRepository.GetAll();
            var totalItems = category.Count();
            int totalPages = (int)Math.Ceiling((double)totalItems / ITEMS_PER_PAGE);
            if (pageNumber > totalPages)
                return RedirectToAction(nameof(CategoriesAdminController.IndexCate), new { page = totalPages });
            var categorys = category
                    .Skip(ITEMS_PER_PAGE * (pageNumber - 1))
                    .Take(ITEMS_PER_PAGE)
                    .ToList();
            ViewData["pageNumber"] = pageNumber;
            ViewData["totalPages"] = totalPages;
            return View(categorys.AsEnumerable());
        }
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                var post = unitOfWork.CategoryRepository.Find(id.Value);
                if (post != null)
                {
                    return View(post);
                }
            }
            return RedirectToAction(nameof(IndexCate));
        }
        // GET: CategoriesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.CategoryRepository.Create(new Category() { Name = category.Name, UrlSlug = category.Name, Description = category.Description });
                    unitOfWork.SaveChange();
                    return RedirectToAction(nameof(IndexCate));
                }
            }
            catch
            {
                return View();
            }
            return View(category);
        }

        // GET: CategoriesController/Edit/5
        [Authorize(Roles = "Blog_Owner,CONTRIBUTOR")]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var category = unitOfWork.CategoryRepository.Find(id.Value);
                if (category != null)
                {
                    return View(category);
                }
            }
            return RedirectToAction(nameof(IndexCate));
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Blog_Owner,CONTRIBUTOR")]
        public IActionResult Edit(int? id, CategoryViewModel category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    if (id.HasValue)
                    {
                        unitOfWork.CategoryRepository.Update(new Category() { Id = category.Id, Name = category.Name, UrlSlug = category.Name, Description = category.Description });
                        unitOfWork.SaveChange();
                    }
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                return RedirectToAction(nameof(IndexCate));
            }
            return View(category);

        }

        // GET: CategoriesController/Delete/5
        [Authorize(Roles = "Blog_Owner")]
        public IActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                unitOfWork.CategoryRepository.Delete(id.Value);
                unitOfWork.SaveChange();
            }
            return RedirectToAction(nameof(IndexCate));
        }
    }
}
