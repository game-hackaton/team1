using System;
using System.Collections.Generic;
using thegame.Models;

namespace thegame.Services;

public class TestData
{
    public static GameDto AGameDto(int keyPressed)
    {
        var width = 8;
        var height = 8;
        //37 - left
        //38 - up
        //39 - right
        //40 - down
        
        var testCells = Array.Empty<CellDto>();
        switch (keyPressed)
        {
            case 38:
                testCells = new[] { new CellDto("1", new VectorDto { X = 0, Y = 0 }, "color1", "", 0) };
                break;            
            case 39:
                testCells = new[] { new CellDto("1", new VectorDto { X = 7, Y = 7 }, "color1", "", 0) };
                break;            
            case 40:
                testCells = new[] { new CellDto("1", new VectorDto { X = 0, Y = 7 }, "color1", "", 0) };
                break;            
            case 41:
                testCells = new[] { new CellDto("1", new VectorDto { X = 7, Y = 0 }, "color1", "", 0) };
                break;
            
        }
        
        return new GameDto(testCells, true, false, width, height, Guid.Empty, false, 0);
    }
}