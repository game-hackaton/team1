using System;
using System.Drawing;
using System.Linq;
using thegame.Extensions;

namespace thegame.GameModels;

public class Game
{
    public Guid Id { get; set; }
    public Map Map { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int Score { get; set; }

    public bool IsFinished
    {
        get
        {
            for (var i = 0; i < Width; i++)
                for (var j = 0; j < Height; j++)
                {
                    if (Map[i, j] != null)
                        return false;
                }

            return true;
        }
    }
    
    private static Random R = new Random();

    public void DoNextStep(Direction direction)
    {
        GenerateNewCell();
        if (IsFinished)
            return;
        
        Move(direction);
    }

    private void GenerateNewCell()
    {
        var empty = Map
            .GetCellsEnumerable()
            .Where(cell => cell != null)
            .Select(cell => cell.Pos)
            .MinBy(cell => R.Next());

        Map[empty] = R.Next(2) == 0
            ? new Cell(empty) {Score = 2}
            : new Cell(empty) {Score = 4};
    }

    private void Move(Direction direction)
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

    private Point GetPreviousPosition(Direction direction, Point position)
    {
        switch (direction)
        {
            case Direction.Up:
                break;
            case Direction.Right:
                break;
            case Direction.Down:
                break;
            case Direction.Left:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
    }

    private Point? GetNextPosition(Direction direction, Point? position = null)
    {
        switch (direction)
        {
            case Direction.Up:
                break;
            case Direction.Right:
                break;
            case Direction.Down:
                break;
            case Direction.Left:
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
                var current = Map[i, j];
                var previous = Map[i - 1, j];
                if (current.Score == previous.Score)
                {
                    previous.Score *= 2;
                }

                Map[i, j] = null;
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
                var current = Map[i, j];
                var previous = Map[i + 1, j];
                if (current.Score == previous.Score)
                {
                    previous.Score *= 2;
                }

                Map[i, j] = null;
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
                var current = Map[i, j];
                var previous = Map[i, j - 1];
                if (current.Score == previous.Score)
                {
                    previous.Score *= 2;
                }

                Map[i, j] = null;
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
                var current = Map[i, j];
                var previous = Map[i, j + 1];
                if (current.Score == previous.Score)
                {
                    previous.Score *= 2;
                }

                Map[i, j] = null;
            }
        }
    }
}