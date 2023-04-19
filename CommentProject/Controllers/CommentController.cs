using CommentProject.BusinessLayer.Abstract;
using CommentProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CommentProject.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITitleService _titleService;
        public CommentController(ICommentService commentService, UserManager<AppUser> userManager, ITitleService titleService)
        {
            _commentService = commentService;
            _userManager = userManager;
            _titleService = titleService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<SelectListItem> values = (from x in _titleService.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.TitleName,
                                               Value = x.TitleID.ToString()
                                           }).ToList();

            ViewBag.v = values;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Comment comment)
        {
            comment.CommentStatus = true;
            comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            var commentUserID = await _userManager.FindByNameAsync(User.Identity.Name);
            comment.AppUserID = commentUserID.Id;
            _commentService.TInsert(comment);
            return RedirectToAction("Index", "Default");
        }

        public async Task<IActionResult> MyComments()
        {
            var commentUserID = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _commentService.TGetCommentsByUserWithTitle(commentUserID.Id);
            return View(values);
        }
    }
}
