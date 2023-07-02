using System;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.ServerModels;
using thegame.Services;

namespace thegame.Controllers;

[Route("api/games")]
public class GamesController : Controller
{
    [HttpPost]
    public IActionResult Index([FromQuery] int fieldSize)
    {
        var game = GamesRepository.GenerateGame(fieldSize, fieldSize);
        var res = new GameDto(game.PaintGame(), true, true, game.Width, game.Height, game.id, game.IsFinish, 0);
        return Ok(res);
    }
}