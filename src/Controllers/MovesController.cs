using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.ServerModels;
using thegame.Services;

namespace thegame.Controllers;

[Route("api/games/{gameId}/moves")]
public class MovesController : Controller
{
    [HttpPost]
    public IActionResult Moves(Guid gameId, [FromBody] UserInputDto userInput)
    {
        var d = (userInput.ClickedPos) ?? (new VectorDto { X = 1, Y = 1 });
        var game = TestData.AGameDto(d);
        // var game = new GameDto(4, 4);
        var cell = game.Cells.First(c => c.Type == "color4");
        var dir = GetDirection(userInput.KeyPressed);
        switch (dir)
        {
            case Direction.LEFT:
            {
                cell.Pos.X -= 1; 
                break;
            } 
            case Direction.RIGHT:
            {
                cell.Pos.X += 1; 
                break;
            } 
            case Direction.UP:
            {
                cell.Pos.Y += 1; 
                break;
            } 
            case Direction.DOWN:
            {
                cell.Pos.Y -= 1; 
                break;
            } 
        }
        return Ok(game);
    }

    private Direction GetDirection(int keyPressed)
    {
        return keyPressed switch
        {
            37 => Direction.LEFT,
            38 => Direction.UP,
            39 => Direction.RIGHT,
            40 => Direction.DOWN,
            _ => Direction.UNKNOWN
        };
    }
    
}



