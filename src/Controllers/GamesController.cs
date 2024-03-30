using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using thegame.GameModels;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers;

[Route("api/games")]
public class GamesController : Controller
{
    private Game _game = new ();
    private readonly IMapper _mapper;
    public GamesController(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    [HttpPost]
    public IActionResult Index()
    {
        var a = _mapper.Map<GameDto>(_game);
        var b = _mapper.Map<GameDto>(_game);
        
        return Ok(_mapper.Map<GameDto>(_game));
    }
}