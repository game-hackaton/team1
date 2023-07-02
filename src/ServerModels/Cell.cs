using System.Collections;
using System.Numerics;
using thegame.Models;

namespace thegame.ServerModels;

public class Cell
{
    private static int IdCount = 0;
    public Vector pos { get; set; }
    public int id { get; }
    public string type { get; set; }
    public int content { get; set; }
    public int zindex { get; set; }
    
    public Cell(Vector pos, string type, int content)
    {
        id = ++IdCount;
        this.pos = pos;
        this.type = type;
        this.content = content;
        zindex = 0;
    }

    public CellDto ToDto()
    {
        var res = (content == 0) ? "" : content.ToString();
        return new CellDto(id.ToString(), pos.ToDto(), type, res, zindex);
    }
    
}