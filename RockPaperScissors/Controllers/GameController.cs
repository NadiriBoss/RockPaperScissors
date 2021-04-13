using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RockPaperScissors.Models;

namespace RockPaperScissors.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class GameController : ControllerBase
  {

    [HttpPost]
    public ActionResult<Game> CreateGame(String playerOneName)
    {
      // create a new instance of a game
      Game game = new Game
      {
        GameID = Guid.NewGuid(),
        Status = "START GAME",
        player = new Game.Player
        {
          Name = playerOneName
        },
      };

      return game;
    }

    [HttpPost("{id}/join")]
    public ActionResult<Game> JoinGame()
    {

      return null;
    }

    [HttpPost("{id}/move")]
    public ActionResult<Game> PlayGame(String player2Name)
    {

      return null;
    }

    [HttpGet("{id}")]
    public ActionResult<Game> GameStatus()
    {

      return null;
    }
  }
}
