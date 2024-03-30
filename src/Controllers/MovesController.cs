using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using thegame.Extensions;
using thegame.GameModels;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers;

[Route("api/games/{gameId}/moves")]
public class MovesController : Controller
{
    private readonly IMapper _mapper;
    public MovesController(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    private Game _game = new();
    
    [HttpPost]
    public IActionResult Moves(Guid gameId, [FromBody]UserInputDto userInput)
    {
        //var game = TestData.AGameDto(userInput.ClickedPos ?? new VectorDto {X = 1, Y = 1});
        
        // var game = TestData.AGameDto(userInput.KeyPressed);
        // if (userInput.ClickedPos != null)
        //     game.Cells.First(c => c.Type == "color4").Pos = userInput.ClickedPos;
        
        _game.DoNextStep(userInput.KeyPressed.GetDirection());

        var a = _mapper.Map<GameDto>(_game);
        var b = _mapper.Map<GameDto>(_game);
        
        return Ok(a);
    }
}