using System;
using System.Drawing;
using System.Numerics;

namespace thegame.GameModels;

public class Cell
{
    public Cell(Vector2 position)
    {
        Pos = position;
        Id = new Guid();
    }
    
    public Guid Id { get; set; }
    public Vector2 Pos { get; set; }
    public int Score { get; set; }
}