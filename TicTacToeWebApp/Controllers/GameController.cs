using Microsoft.AspNetCore.Mvc;
using TicTacToeWebApp.Models;

namespace TicTacToeWebApp.Controllers;

public class GameController : Controller
{
    // GET
    public Board board = new Board(); 
    public IActionResult Index(Board b)
    {
        return View(b);
    }
}