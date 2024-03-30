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
        switch (direction)
        {
            case Direction.Up:
                MoveUp();
                break;            
            case Direction.Left:
                MoveLeft();
                break;
            case Direction.Right:
                MoveRight();
                break;
            case Direction.Down:
                MoveDown();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
    }

    private void MoveLeft()
    {
        for (var i = 0; i < Width; i++)
        {
            for (var j = 0; j < Height; j++)
            {
                if (i == 0 || i == Width - 1) continue;
                if (j == 0 || j == Height - 1) continue;
                var current = Cells[i, j];
                var previous = Cells[i - 1, j];
                if (current.Score == previous.Score)
                {
                    previous.Score *= 2;
                }

                Cells[i, j] = null;
            }
        }
    }
    
    private void MoveRight()
    {
        for (var i = Width - 1; i >= 0; i++)
        {
            for (var j = 0; j < Height; j++)
            {
                if (i == 0 || i == Width - 1) continue;
                if (j == 0 || j == Height - 1) continue;
                var current = Cells[i, j];
                var previous = Cells[i + 1, j];
                if (current.Score == previous.Score)
                {
                    previous.Score *= 2;
                }

                Cells[i, j] = null;
            }
        }
    }
    
    private void MoveUp()
    {
        for (var i = 0; i < Width; i++)
        {
            for (var j = 0; j < Height; j++)
            {
                if (i == 0 || i == Width - 1) continue;
                if (j == 0 || j == Height - 1) continue;
                var current = Cells[i, j];
                var previous = Cells[i, j - 1];
                if (current.Score == previous.Score)
                {
                    previous.Score *= 2;
                }

                Cells[i, j] = null;
            }
        }
    }
    
    private void MoveDown()
    {
        for (var i = 0; i < Width; i++)
        {
            for (var j = Height - 1; j >= 0; j++)
            {
                if (i == 0 || i == Width - 1) continue;
                if (j == 0 || j == Height - 1) continue;
                var current = Cells[i, j];
                var previous = Cells[i, j + 1];
                if (current.Score == previous.Score)
                {
                    previous.Score *= 2;
                }

                Cells[i, j] = null;
            }
        }
    }
}