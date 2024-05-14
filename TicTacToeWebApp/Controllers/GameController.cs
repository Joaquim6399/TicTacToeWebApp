using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TicTacToeWebApp.Models;

namespace TicTacToeWebApp.Controllers;

public class GameController : Controller
{
    // GET
    public IActionResult Index()
    {
        Board board = GetBoardFromSession();
        return View(board);
    }

    public IActionResult ChooseCell(int id)
    {
        Board board = GetBoardFromSession();
        int x = (id - 1) / 3;
        int y = (id - 1) % 3;

        if (board.IsPlayerX)
        {
            board.BoardGrid[x, y] = "X";
            board.IsPlayerX = false;
        }
        else
        {
            board.BoardGrid[x, y] = "O";
            board.IsPlayerX = true;
            
        }

        if (board.hasPlayerWon())
            board.IsThereWinner = true;
        
        SaveBoardToSession(board);
        
         
        
        return RedirectToAction("Index");
    }

    public IActionResult RestartGame()
    {
        Board board = new Board();
        var boardJson = JsonConvert.SerializeObject(board);
        HttpContext.Session.SetString("Board", boardJson);
        
        return RedirectToAction("Index");
         
    }
    private Board GetBoardFromSession()
    {
        var boardJson = HttpContext.Session.GetString("Board");
        if (string.IsNullOrEmpty(boardJson))
        {
            return new Board();
        }
        return JsonConvert.DeserializeObject<Board>(boardJson);
    }
    
    private void SaveBoardToSession(Board board)
    {
        var boardJson = JsonConvert.SerializeObject(board);
        HttpContext.Session.SetString("Board", boardJson);
    }
}