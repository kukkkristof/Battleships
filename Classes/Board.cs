using System.Drawing;

namespace Battleships;
public class Board
{
    public Point Position = new Point(0,0);
    public Ship[] Ships = new Ship[5];
    public string PlayerName = "Player";
    public static Ship[] GetDefaultShips()
    {
        Ship[] returnValue = new Ship[5];
        for(int shipNo = 1; shipNo <= 5; shipNo++)
        {
            returnValue[shipNo-1] = new Ship();
            if(shipNo%5 == 0)
            {
                returnValue[shipNo-1].Type = Ship.type.Lshape5;
                continue;
            }
            if(shipNo%2 == 0)
            {

            } 
        }
        return returnValue;
    }
}
