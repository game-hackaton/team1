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
    public IActionResult Index()
    {
        // return Ok(TestData.AGameDto(new VectorDto {X = 1, Y = 1}));
        var game = new Game(4, 4);
        game.ResetGame();
        var res = new GameDto(game.PaintGame(), true, true, 4, 4, Guid.Empty, false, 0);
        return Ok(res);
    }
}