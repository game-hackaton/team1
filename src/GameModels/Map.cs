using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;

namespace thegame.GameModels;

public class Map
{
    private readonly int _bounds;
    private Cell[,] _cells;
    
    public Map(int bounds)
    {
        _bounds = bounds;
        _cells = new Cell[bounds, bounds];
    }

    [Obsolete]
    public Point Add(Cell cell)
    {
        for (var i = 0; i < _bounds; i++)
        for (var j = 0; j < _bounds; j++)
            if (_cells[i, j] is null)
            {
                _cells[i, j] = cell;
                cell.Pos = new Point(i, j);
                return cell.Pos;
            }

        throw new InvalidOperationException();
    }

    public IEnumerable<Cell> GetCellsEnumerable() => _cells.Cast<Cell>();

    public Cell this[Point indexes]
    {
        get => _cells[indexes.X, indexes.Y];
        set => _cells[indexes.X, indexes.Y] = value;
    }

    public Cell this[int x, int y]
    {
        get => _cells[x, y];
        set => _cells[x, y] = value;
    }
}