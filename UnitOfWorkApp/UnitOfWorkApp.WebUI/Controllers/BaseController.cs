using System.Web.Mvc;
using UnitOfWorkApp.Domain.Concrete;

namespace UnitOfWorkApp.WebUI.Controllers
{
    public class BaseController : Controller
    {
        protected EFUnitOfWork dal;

        public BaseController()
        {
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            //initialize
            dal = new EFUnitOfWork();
        }
    }
}