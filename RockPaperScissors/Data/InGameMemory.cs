using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RockPaperScissors.Models;

namespace RockPaperScissors.Data
{
  public class InGameMemory : IInGameMemory
  {
    // save game in List
    private readonly List<Game> games = new()
    {
    };

    // Create game
    public void CreateGame(Game game)
    {
      games.Add(game);
    }

    // Get game with game Id
    public Game GetGame(Guid id)
    {
      return games.Where(game => game.GameID == id).SingleOrDefault();
    }

    // get all the games
    public IEnumerable<Game> GetGames()
    {
      return games;
    }
  }
}

