using FA.JustBlog.Core.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Controllers
{
    public class CommentController : Controller
    {
        private IUnitOfWork unitOfWork;
        public CommentController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: CommentController/Create
        //public ActionResult Create(CommentViewModel cmt)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            unitOfWork.CommentRepositoty.Create(new Comment {Id=cmt.Id, CommentHeader= cmt.CommentHeader, CommentText = cmt.CommentText, Name = cmt.Name, Email = cmt.Email});
        //            unitOfWork.SaveChange();
        //            return RedirectToAction("Detail");
        //        }
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //    return View(category);
        //}

    }
}
