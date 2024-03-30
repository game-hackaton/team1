using System;
using thegame.GameModels;

namespace thegame.Services;

public interface IRepository
{
    public void Add(Game game);
    public Game FindById(Guid id);
}