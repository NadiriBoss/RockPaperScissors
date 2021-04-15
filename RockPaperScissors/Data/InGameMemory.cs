using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RockPaperScissors.Models;

namespace RockPaperScissors.Data
{
  public class InGameMemory : IInGameMemory
  {
    private readonly List<Game> games = new()
    {

    };

    public void CreateGame(Game game)
    {
      games.Add(game);
    }

    public Game GetGame(Guid id)
    {

      return games.Where(game => game.GameID == id).SingleOrDefault();

    }

    public IEnumerable<Game> GetGames()
    {
      return games;
    }
  }
}

