using System;
using System.Drawing;
using System.Linq;
using thegame.Extensions;

namespace thegame.GameModels;

public class Game
{
    public Guid Id { get; set; }
    public Cell[,] Cells { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    
    public static Random R= new Random();

    public bool IsFinished
    {
        get
        {
            for (var i = 0; i < Width; i++)
                for (var j = 0; j < Height; j++)
                {
                    if (Cells[i, j] != null)
                        return false;
                }

            return true;
        }
    }
    public int Score { get; set; }

    public void GenerateNewCell()
    {
        var empty = Cells
            .Cast<Cell>()
            .Where(cell => cell != null)
            .Select(cell => cell.Pos)
            .MinBy(cell => R.Next());

        Cells[(int)empty.X, (int)empty.Y] = R.Next(2) == 0
            ? new Cell(empty) {Score = 2}
            : new Cell(empty) {Score = 4};
    }

    public bool CheckMoveIsPossible(Direction direction)
    {
        throw new NotImplementedException();
    }

    private bool CellCanMove(Direction direction, Point pos)
    {
        var dir = direction.GetPoint();
        throw new NotImplementedException();
    }

    public void Move(Direction direction)
    {
        // if direction == left
        for (var i = 0; i < Width; i++)
        {
            for (var j = 0; j < Height; j++)
            {
                if (i == 0 || i == Width - 1) continue;
                if (j == 0 || j == Height - 1) continue;
                var current = Cells[i, j];
                var previous = Cells[i - 1, j - 1];
                if (current.Score == previous.Score)
                {
                    previous.Score *= 2;
                }

                Cells[i, j] = null;
            }
        }
    }
}