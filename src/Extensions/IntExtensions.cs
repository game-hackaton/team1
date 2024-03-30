using thegame.GameModels;

namespace thegame.Extensions;

public static class IntExtensions
{
    public static Direction GetFromKeycode(this int keyCode)
    {
        return keyCode switch
        {
            37 => Direction.Left,
            38 => Direction.Up,
            39 => Direction.Right,
            40 => Direction.Down,
            _ => Direction.None
        };
    }
}