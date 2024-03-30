using System;
using System.Drawing;
using thegame.GameModels;

namespace thegame.Extensions;

public static class DirectionExtensions
{
    public static Point GetPoint(this Direction direction)
    {
        throw new NotImplementedException();
    }

    public static int GetKeycode(this Direction direction)
    {
        return direction switch
        {
            Direction.Left => 37,
            Direction.Up => 38,
            Direction.Right => 39,
            Direction.Down => 40,
            _ => 0
        };
    }
}