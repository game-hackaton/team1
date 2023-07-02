using System;
using System.Collections.Generic;
using System.Linq;
using thegame.Models;

namespace thegame.ServerModels;

public class Game
{
    public List<Cell> Cells { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public Game(int Width, int Height)
    {
        Cells = new List<Cell>();
        this.Width = Width;
        this.Height = Height;
    }

    public void ResetGame()
    {
        Cells.Clear();
        for (int X = 0; X < Width; X++)
        {
            for (int Y = 0; Y < Height; Y++)
            {
                Cells.Add(new Cell(new Vector{X = X, Y = Y}, "td", 0 ));
            }
        }
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