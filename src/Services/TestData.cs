using System;
using System.Collections.Generic;
using thegame.Extensions;
using thegame.Models;

namespace thegame.Services;

public class TestData
{
    public static GameDto AGameDto(int keyPressed)
    {
        var width = 4;
        var height = 4;
        var testCells = Array.Empty<CellDto>();
        switch (keyPressed)
        {
            case 37:
                testCells = new[] { new CellDto("1", new VectorDto { X = 0, Y = 1 }, "color1", "", 0) };
                break;            
            case 38:
                testCells = new[] { new CellDto("1", new VectorDto { X = 1, Y = 0 }, "color1", "", 0) };
                break;            
            case 39:
                testCells = new[] { new CellDto("1", new VectorDto { X = 3, Y = 1 }, "color1", "", 0) };
                break;            
            case 40:
                testCells = new[] { new CellDto("1", new VectorDto { X = 1, Y = 3 }, "color1", "", 0) };
                break;
            
        }
        
        return new GameDto(testCells, true, false, width, height, Guid.Empty, false, 0);
    }
}