using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using thegame.Models;

namespace thegame.ServerModels;

public class Cell
{
    private static int IdCount = 0;
    public Vector pos { get; set; }
    public int id { get; }

    private static Dictionary<int, string> type = new Dictionary<int, string>
    {
        { 0, "td" },
        { 2, "tile-2" },
        { 4, "tile-4" },
        {8, "tile-8"},
        {16, "tile-16"},
        {32, "tile-32"},
        {64, "tile-64"},
        {128, "tile-128"},
        {256, "tile-256"},
        {512, "tile-512"},
        {1024, "tile-1024"},
        {2048, "tile-2048"},
    };
    public int content { get; set; }
    public int zindex { get; set; }
    
    public Cell(Vector pos, int content)
    {
        id = ++IdCount;
        this.pos = pos;
        this.content = content;
        zindex = 0;
    }

    public CellDto ToDto()
    {
        var res = (content == 0) ? "" : content.ToString();
        return new CellDto(id.ToString(), pos.ToDto(), type[content], res, zindex);
    }
    
}