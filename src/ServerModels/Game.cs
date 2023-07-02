using System;
using System.Linq;
using thegame.Models;

namespace thegame.ServerModels;

public class Game
{
    public Cell[] Cells { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public Game(int Width, int Height)
    {
        this.Cells = null;
        this.Width = Width;
        this.Height = Height;
    }

    private Cell GetCellByCoordinate(int x, int y)
    {
        foreach (var cell in Cells)
        {
            if (cell.pos.X == x && cell.pos.Y == y)
            {
                return cell;
            }
        }

        return null;
    }
    
    public GameDto PaintGame()
    {
        var testCells = new CellDto[Width * Height];
        for (int i = 1; i <= Width; i++)
        {
            for (int j = 1; j <= Height; j++)
            {
                var cell = GetCellByCoordinate(i, j);
                if (cell != null)
                {
                    //testCells[] = cell.ToDto();
                }
            }
        }
    }
    
}