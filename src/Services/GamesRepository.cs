using System;
using System.Collections.Generic;
using thegame.ServerModels;

namespace thegame.Services;

public class GamesRepository
{
    private static Dictionary<Guid, Game> Games = new Dictionary<Guid, Game>();
    private static Game getGameByGuid(Guid g)
    {
        if (Games.ContainsKey(g))
        {
            return Games[g];
        }

        return null;
    }

    public static Game GenerateGame()
    {
        var width = 4;
        var height = 4;
        var game = new Game(width, height);
        Guid id = Guid.NewGuid();
        game.id = id;
        Games.Add(id, game);
        game.ResetGame();
        // game.PaintGame();
        return game;
    }
    
}