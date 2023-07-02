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
        var game = GamesRepository.GenerateGame();
        var res = new GameDto(game.PaintGame(), true, true, game.Width, game.Height, game.id, game.IsFinish, 0);
        return Ok(res);
    }
}