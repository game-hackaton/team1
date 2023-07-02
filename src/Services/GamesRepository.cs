using System;
using System.Collections.Generic;
using thegame.ServerModels;

namespace thegame.Services;

public class GamesRepository
{
    private static Dictionary<Guid, Game> Games = new Dictionary<Guid, Game>();
    private static Game? getGameByGuid(Guid g)
    {
        if (Games.ContainsKey(g))
        {
            return Games[g];
        }

        return null;
    }

    public static Game MakeChanges(Guid id, Direction direction)
    {
        var game = getGameByGuid(id);
        game?.Move(direction);
        return game;
    }
    public static Game GenerateGame(int width, int height)
    {
        var game = new Game(width, height);
        Guid id = Guid.NewGuid();
        game.id = id;
        Games.Add(id, game);
        game.ResetGame();
        // game.PaintGame();
        return game;
    }
    
}