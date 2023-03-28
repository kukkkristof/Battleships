using System.Drawing;
using Pastel;

namespace Battleships;
public class GameManager
{
    public int MaxUserNameLenght = 15;
    string player1, player2;
    public void Setup()
    {
        getUserNames();
    }
    void getUserNames()
    {
        Console.BackgroundColor = ConsoleColor.Cyan;
        Console.SetCursorPosition(1,2);
        for(int i = 0; i <= 2; i++)
        {
            if(i%2 == 0)
            {
                for(int j = 0; j < MaxUserNameLenght; j++)
                {
                    Console.Write("█".Pastel(Color.FromArgb(255,255,0)));
                }
                Console.SetCursorPosition(1,3);
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Cyan;
                for(int j = 0; j < MaxUserNameLenght; j++)
                {
                    if(j == 0 || j == MaxUserNameLenght-1) Console.Write("█".Pastel(Color.FromArgb(255,255,0)));
                    else
                    {
                        
                        Console.Write(" ");
                    }
                }
                Console.SetCursorPosition(1,4);
            }
        }
        Console.SetCursorPosition(2,3);
        Console.BackgroundColor = ConsoleColor.Cyan;
    }
}
