using System;
using System.Collections.Generic;
using System.Linq;
using thegame.Extensions;
using thegame.Models;

namespace thegame.Services;

public class TestData
{
    private static CellDto[] cell = new[] { new CellDto("1", new VectorDto { X = 0, Y = 1 }, "color1", "", 0) };

    // public static GameDto AGameDto(int keyPressed)
    // {
    //     var width = 4;
    //     var height = 4;
    //     
    //     switch (keyPressed)
    //     {
    //         case 37:
    //             cell.First().Pos.X = 0;
    //             break;
    //         case 38:
    //             cell.First().Pos.Y = 0;
    //             break;
    //         case 39:
    //             cell.First().Pos.X = 3;
    //             break;
    //         case 40:
    //             cell.First().Pos.Y = 3;
    //             break;
    //     }
    //
    //     return new GameDto(cell, true, false, width, height, Guid.Empty, false, 0);
    // }
}