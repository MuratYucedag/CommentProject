using CommentProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CommentProject.ViewComponents.Title
{
    public class _TitleList : ViewComponent
    {
        private readonly ITitleService _titleService;
        public _TitleList(ITitleService titleService)
        {
            _titleService = titleService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _titleService.TGetList();
            return View(values);
        }
    }
}
