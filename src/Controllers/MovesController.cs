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
        var game = GamesRepository.MakeChanges(gameId, GetDirection(userInput.KeyPressed));
        var res = new GameDto(game.PaintGame(), true, true, game.Width, game.Height, game.id, game.IsFinish, game.Score);
        return Ok(res);
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



