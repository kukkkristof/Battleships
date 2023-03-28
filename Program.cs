using System.Security.AccessControl;
using Battleships;
using Pastel;

UtilityCommands.Maximize();
Console.BackgroundColor = ConsoleColor.Cyan;
Console.Clear();

beginning:
Console.BackgroundColor = ConsoleColor.Cyan;
GameManager manager = new GameManager();
manager.MaxUserNameLenght = 20;
manager.Setup();

end:
Console.ReadLine();
