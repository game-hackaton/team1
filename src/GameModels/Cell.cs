using System;
using System.Drawing;

namespace thegame.GameModels;

public class Cell
{
    public Cell(Point position)
    {
        Pos = position;
        Id = new Guid();
    }

    public Cell(int score)
    {
        Id = Guid.NewGuid();
        Score = score;
    }
    
    public Guid Id { get; set; }
    public Point Pos { get; set; }
    public int Score { get; set; }
    public int Pow { get; set; }
}