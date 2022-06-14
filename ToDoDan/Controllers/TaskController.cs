using Microsoft.AspNetCore.Mvc;

namespace ToDoDan.Controllers;

public class TaskController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}