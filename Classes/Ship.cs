using System.Drawing;
namespace Battleships;
public class Ship
{
    public enum type
    {
        Basic2,
        Basic3,
        Basic4,
        Basic5,
        Lshape3,
        Lshape4,
        Lshape5
    };
    public type Type = type.Basic2;
    public Point position = new Point(0,0);
}
