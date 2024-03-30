using System;

namespace thegame.GameModels;

public class Game
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Map Map { get; set; }
    public int Width { get; set; } = 4;
    public int Height { get; set; } = 4;
    public int Score { get; set; }

    public Game()
    {
        Map = new Map(Width);
        Map.Add(new Cell(R.Next(5) == 0 ? 4 : 2));
    }

    public bool IsFinished
    {
        get
        {
            for (var i = 0; i < Width; i++)
            for (var j = 0; j < Height; j++)
                if (Map[i, j] is not null)
                    return true;

            return false;
        }
    }
    
    private static Random R = new Random();

    public void DoNextStep(Direction direction)
    {
        if (IsFinished)
            return;

        Map.Add(new Cell(R.Next(2) == 0 ? 4 : 2));
        Move(direction);
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
        }
    }

    private void MoveLeft()
    {
        for (var i = 0; i < Width; i++)
        for (var j = 0; j < Height; j++)
            ProceedCell(i, j, -1, 0);
    }
    
    private void MoveRight()
    {
        for (var i = Width - 1; i >= 0; i++)
        for (var j = 0; j < Height; j++)
            ProceedCell(i, j, 1, 0);
    }
    
    private void MoveUp()
    {
        for (var i = 0; i < Width; i++)
        for (var j = 0; j < Height; j++)
            ProceedCell(i, j, 0, -1);
    }
    
    private void MoveDown()
    {
        for (var i = 0; i < Width; i++)
        for (var j = Height - 1; j >= 0; j--)
            ProceedCell(i, j, 0, 1);
    }
    
    private void ProceedCell(int i, int j, int deltaX, int deltaY)
    {
        if (!Map.IsInBounds(i + deltaX, j + deltaY))
            return;
        
        var current = Map[i, j];
        var previous = Map[i + deltaX, j + deltaY];
            
        if (current.Score == previous.Score)
        {
            previous.Score *= 2;
            previous.Pow += 1;
        }

        Map[i, j] = null;
    }
}