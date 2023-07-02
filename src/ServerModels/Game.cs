using System;
using System.Collections.Generic;
using System.Linq;
using thegame.Models;

namespace thegame.ServerModels;

public class Game
{
    public List<Cell> Cells { get; set; }
    public int Width { get; set; }
    public Guid id { get; set; }
    public int Height { get; set; }

    private int _Score;
    public int Score
    {
        get
        {
            return _Score;
        }
    }

    private bool Finish;

    public bool IsFinish
    {
        get { return Finish; }
    }

    public Game(int Width, int Height)
    {
        _Score = 0;
        Cells = new List<Cell>();
        this.Width = Width;
        this.Height = Height;
    }

    private void AddNewCell()
    {
        var emptyCell = new List<Cell>();
        foreach (var cell in Cells)
        {
            if (cell.content == 0)
            {
                emptyCell.Add(cell);
            }
        }

        if (emptyCell.Count == 0)
        {
            Finish = true;
            return;
        }

        var rnd = new Random();
        var indx = rnd.Next(0, emptyCell.Count);
        emptyCell[indx].content = rnd.Next(1, 3) * 2;
    }

    public void ResetGame()
    {
        Cells.Clear();
        Finish = false;
        for (int X = 0; X < Width; X++)
        {
            for (int Y = 0; Y < Height; Y++)
            {
                Cells.Add(new Cell(new Vector { X = X, Y = Y }, 0));
            }
        }

        AddNewCell();
    }

    public CellDto[] PaintGame()
    {
        var testCells = new List<CellDto>();
        foreach (var cell in Cells)
        {
            testCells.Add(cell.ToDto());
        }

        return testCells.ToArray();
    }

    public void Move(Direction dir)
    {
        int napr = -1;
        switch (dir)
        {
            case Direction.LEFT:
                napr = 1;
                break;
            case Direction.RIGHT:
                napr = -1;
                break;
            case Direction.UP:
                napr = 1;
                break;
            case Direction.DOWN:
                napr = -1;
                break;
            default:
                return;
        }

        if (!(dir == Direction.UP || dir == Direction.DOWN))
        {
            for (int i = 0; i < Width; i++)
            {
                int[] oldRow = new int[Height];
                for (int j = 0; j < Height; j++)
                {
                    oldRow[j] = Cells.First((c => c.pos.X == j && c.pos.Y == i)).content;
                }

                int[] newRow = MoveRow(oldRow, napr);
                for (int j = 0; j < Height; j++)
                {
                    Cells.First((c => c.pos.X == j && c.pos.Y == i)).content = newRow[j];
                }
            }
        }
        else
        {
            for (int j = 0; j < Height; j++)
            {
                int[] oldRow = new int[Width];
                for (int i = 0; i < Width; i++)
                {
                    oldRow[i] = Cells.First((c => c.pos.X == j && c.pos.Y == i)).content;
                }

                int[] newRow = MoveRow(oldRow, napr);
                for (int i = 0; i < Width; i++)
                {
                    Cells.First((c => c.pos.X == j && c.pos.Y == i)).content = newRow[i];
                }
            }
        }

        AddNewCell();
    }

    private int[] MoveRow(int[] oldRow, int napr)
    {
        var old = oldRow.ToList();
        var oldRowWithoutZeroes = new int[old.Count];
        if (napr == -1)
        {
            old.Reverse();
        }

        int q = 0;
        int i;
        for (i = 0; i < oldRow.Length; i++)
        {
            if (oldRow[i] != 0)
            {
                oldRowWithoutZeroes[q] = oldRow[i];
                q++;
            }
        }

        var shiftedRow = new int[old.Count];
        q = 0;
        i = 0;
        while (i < oldRowWithoutZeroes.Length)
        {
            if ((i + 1 < oldRowWithoutZeroes.Length) && (oldRowWithoutZeroes[i] == oldRowWithoutZeroes[i + 1])
                                                     && oldRowWithoutZeroes[i] != 0)
            {
                bool didAnythingMove = true;
                shiftedRow[q] = oldRowWithoutZeroes[i] * 2;
                _Score += shiftedRow[q];
                i++;
            }
            else
            {
                shiftedRow[q] = oldRowWithoutZeroes[i];
            }

            q++;
            i++;
        }

        var buff = shiftedRow.ToList();
        if (napr == -1)
        {
            buff.Reverse();
        }
        
        return buff.ToArray();
    }
}