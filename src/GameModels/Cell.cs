using System.Drawing;

namespace thegame.GameModels;

public class Cell
{
    public string Id { get; set; }
    public Point Pos { get; set; }
    public int ZIndex { get; set; }
    public int Score { get; set; }
    public string Content { get; set; }
}