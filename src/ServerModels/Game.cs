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
    
}