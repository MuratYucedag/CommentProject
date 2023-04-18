using Microsoft.AspNetCore.Mvc;

namespace CommentProject.ViewComponents.Title
{
    public class _HeadPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
