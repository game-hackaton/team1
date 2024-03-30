using System;
using System.Collections.Generic;
using thegame.GameModels;

namespace thegame.Services;

public class GamesRepository
{
    private Dictionary<Guid, Game> dictionary = new();

    public void Add(Game game)
    {
        dictionary[game.Id] = game;
    }

    public Game? FindById(Guid id)
    {
        dictionary.TryGetValue(id, out var game);
        return game;
    }
}