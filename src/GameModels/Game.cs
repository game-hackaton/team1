using System;
using System.Drawing;
using thegame.Extensions;

namespace thegame.GameModels;

public class Game
{
    public Guid Id { get; set; }
    public Cell[,] Cells { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public bool IsFinished
    {
        get
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if (Cells[i, j] != null)
                        return false;
                }
            }

            return true;
        }
    }
    public int Score { get; set; }

    public void GenerateNewCell()
    {
        
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