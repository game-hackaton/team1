using System.Drawing;
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
    }
    
    public Cell this[Point indexes] => _cells[indexes.X, indexes.Y];
}