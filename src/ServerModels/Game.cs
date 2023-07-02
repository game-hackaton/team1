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

    private bool Finish;
    public bool IsFinish
    {
        get { return Finish; }
    }

    public Game(int Width, int Height)
    {
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
        var indx = rnd.Next(0, emptyCell.Count + 1);
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
                Cells.Add(new Cell(new Vector{X = X, Y = Y}, 0 ));
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
        int begin = -1;
        int end = -1;
        int napr = -1;
        switch (dir)
        {
            case Direction.LEFT:
                begin = -1;
                end = Width;
                napr = 1;
                break;
            case Direction.RIGHT:
                begin = Width;
                end = -1;
                napr = -1;
                break;
            case Direction.UP:
                begin = Height;
                end = -1;
                napr = -1;
                break;
            case Direction.DOWN:
                begin = -1;
                end = Height;
                napr = 1;
                break;
        }

        if (dir == Direction.UP || dir == Direction.DOWN)
        {
            for (int i = 0; i < Width; i++)
            {
                int[] oldRow = new int[Height];
                for (int j = 0; j < Height; j++)
                {
                    oldRow[j] = Cells.First((c => c.pos == new Vector {X = i, Y = j})).content;
                }

                int[] newRow = MoveRow(oldRow, begin, end, napr);
                for (int j = 0; j < Height; j++)
                {
                    Cells.First((c => c.pos == new Vector {X = i, Y = j})).content = newRow[j];
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
                    oldRow[i] = Cells.First((c => c.pos == new Vector {X = i, Y = j})).content;
                }

                int[] newRow = MoveRow(oldRow, begin, end, napr);
                for (int i = 0; i < Width; i++)
                {
                    Cells.First((c => c.pos == new Vector {X = i, Y = j})).content = newRow[i];
                }
            }
        }
    }

    private int[] MoveRow(int[] oldRow, int begin, int end, int napr)
    {
        int[] oldRowWithoutZeroes = new int[oldRow.Length];
        int q = begin;
        int i = begin;
        while ((napr == 1 && i<end)||(napr == -1 && i>end))
        {
            if (oldRow[i] != 0)
            {
                oldRowWithoutZeroes[q] = oldRow[i];
                q+=napr;
            }

            i += napr;
        }

        int[] shiftedRow = new int[oldRowWithoutZeroes.Length];
        q = begin;
        int index = begin;
        while ((napr == 1 && index < oldRowWithoutZeroes.Length) || (napr == -1 && index > 0))

        {
            if ((index + napr < oldRowWithoutZeroes.Length) && (oldRowWithoutZeroes[index] ==
                                                                oldRowWithoutZeroes[index + napr])
                                                            && oldRowWithoutZeroes[index] != 0)
            {
                shiftedRow[q] = oldRowWithoutZeroes[index] * 2;
                index++;
            }
            else
            {
                shiftedRow[q] = oldRowWithoutZeroes[index];
            }

            q += napr;
            index += napr;
        }

        return shiftedRow;
    }
}