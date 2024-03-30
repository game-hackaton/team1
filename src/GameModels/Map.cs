using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;

namespace thegame.GameModels;

public class Map : IEnumerable<Cell>
{
    public int Bounds { get; }
    private Cell[,] _cells;
    
    public Map(int bounds)
    {
        Bounds = bounds;
        _cells = new Cell[bounds, bounds];
    }
    
    public void Add(Cell cell)
    {
        for (var i = 0; i < Bounds; i++)
        for (var j = 0; j < Bounds; j++)
            if (_cells[i, j] is null)
            {
                _cells[i, j] = cell;
                cell.Pos = new Point(i, j);
                return;
            }
    }

    public bool IsInBounds(int i, int j)
    {
        return i >= 0 && i < Bounds
                      && j >= 0 && j < Bounds;
    }
    
    public Cell this[int x, int y]
    {
        get => _cells[x, y];
        set => _cells[x, y] = value;
    }

    public IEnumerator<Cell> GetEnumerator()
    {
        for (var i = 0; i < Bounds; i++)
        for (var j = 0; j < Bounds; j++)
        {
            if (_cells[i, j] is not null)
                yield return _cells[i, j];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}