using RockPaperScissors.Models;
using System;
using System.Collections.Generic;

namespace RockPaperScissors.Data
{
  public interface IInGameMemory
  {
    void CreateGame(Game game);
    Game GetGame(Guid id);
    IEnumerable<Game> GetGames();
  }
}