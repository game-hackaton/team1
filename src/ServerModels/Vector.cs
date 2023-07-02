using thegame.Models;

namespace thegame.ServerModels;

public class Vector
{
    public int X { get; set; }
    public int Y { get; set; }

    public VectorDto ToDto()
    {
        return new VectorDto { X = this.X, Y = this.Y };
    }
}