using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace SignalRWebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutScriptComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
