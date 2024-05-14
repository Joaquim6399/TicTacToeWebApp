namespace TicTacToeWebApp.Models;

public class Board
{
    //Create a 3 x 3 grid
     public string[,] BoardGrid {get; set;}
   
     //Constructor
     public Board() => BoardGrid = new string [3, 3] ;
   
     public bool hasPlayerWon()
     {
       bool hasWon = false;

      //Check all rows
      for (int i = 0; i < 3; i++)
      {
        string row = "";
        for (int j = 0; j < 3; j++)
        {
          row += (string.IsNullOrEmpty(BoardGrid[i, j]) ? "()" : BoardGrid[i, j]);
        }

        Console.WriteLine("row is: " + row);   
        //Check if row has winner
        if (checkWinner(row))
          return true;

      }
       
       //Check all columns
       for (int i = 0; i < 3; i++)
       {
         string column = "";
         for (int j = 0; j < 3; j++)
         {
           column += (string.IsNullOrEmpty(BoardGrid[j, i]) ? "()" : BoardGrid[j, i]);
         }

         Console.WriteLine("column is: " + column);   
         //Check if row has winner
         if (checkWinner(column))
           return true;

       }
 
       //Check across (0,0) (1,1) (2,2) && (0,2) (1,1) (2,0)
       //left to right
       string across = "";
       across += (string.IsNullOrEmpty(BoardGrid[0, 0]) ? "()" : BoardGrid[0, 0]);
       across += (string.IsNullOrEmpty(BoardGrid[1, 1]) ? "()" : BoardGrid[1, 1]);
       across += (string.IsNullOrEmpty(BoardGrid[2, 2]) ? "()" : BoardGrid[2, 2]);

       Console.WriteLine("across is: " + across);
       if (checkWinner(across))
         return true;
       
      //right to left
       across = "";
       across += (string.IsNullOrEmpty(BoardGrid[0, 2]) ? "()" : BoardGrid[0, 2]);
       across += (string.IsNullOrEmpty(BoardGrid[1, 1]) ? "()" : BoardGrid[1, 1]);
       across += (string.IsNullOrEmpty(BoardGrid[2, 0]) ? "()" : BoardGrid[2, 0]);

       Console.WriteLine("across is: " + across);
       if (checkWinner(across))
         return true;
      
       return hasWon;

       bool checkWinner(string line)
       {
         if (line == "XXX" || line == "OOO")
           return true;
         else
           return false;
       }
     }
     public void printBoard()
     {
       for (int i = 0; i < 3; i++)
       {
         for (int j = 0; j < 3; j++)
         {
           Console.Write(string.IsNullOrEmpty(this.BoardGrid[i,j]) ? "( )" : "("+this.BoardGrid[i,j]+")");
         }
         Console.WriteLine();
       }
     }

}