using Microsoft.AspNetCore.Mvc;

namespace TicTacToeWebApp.Controllers;

public class GameController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}