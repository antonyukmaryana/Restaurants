using Microsoft.AspNetCore.Mvc;

namespace ProjectName.Controllers
{
  public class HomeController : Controller
  {

    [Route("/")]
    public ActionResult Home() { return View(); }
  }
}
