using CommentProject.BusinessLayer.Abstract;
using CommentProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CommentProject.Controllers
{
    public class TitleController : Controller
    {
        private readonly ITitleService _titleService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;
        public TitleController(ITitleService titleService, ICategoryService categoryService, UserManager<AppUser> userManager)
        {
            _titleService = titleService;
            _categoryService = categoryService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var values = _titleService.TGetList();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> AddTitle()
        {
            List<SelectListItem> values = (from x in _categoryService.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();

            ViewBag.v = values;        
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTitle(Title title)
        {
            var titleCreatorUser = await _userManager.FindByNameAsync(User.Identity.Name);
            title.AppUserID = titleCreatorUser.Id;
            _titleService.TInsert(title);
            return RedirectToAction("Index");
        }
    }
}
