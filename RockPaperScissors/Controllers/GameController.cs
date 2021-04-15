using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RockPaperScissors.Models;
using RockPaperScissors.Data;

namespace RockPaperScissors.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class GameController : ControllerBase
  {
    private readonly IInGameMemory memory;

    public GameController(IInGameMemory memory)
    {
      this.memory = memory;
    }

    [HttpPost]
    public ActionResult<String> CreateGame(String playerOneName, string  playerOneMove)
    {
      Game game = new Game
      {
        GameID = Guid.NewGuid(),
        Status = "START GAME",
        PlayerOne = new Player
        {
          Name = playerOneName,
          Move = playerOneMove
        }
      };

      memory.CreateGame(game);

      return game.GameID.ToString() 
        + "\n Game status: " + game.Status 
        + "\n Player 1: " + game.PlayerOne.Name;
    }

    [HttpPost("{id}/join")]
    public ActionResult<String> JoinGame(Guid id, string playerTwoName)
    {
      var game = memory.GetGame(id);
      game.PlayerTwo = new Player
      {
        Name = playerTwoName
      };
      game.Status = "JOINING";

      return "Game ID" + game.GameID.ToString() 
        + "\n Game status: " + game.Status 
        + "\n Player 1: " + game.PlayerOne.Name
        + "\n Player 2: " + game.PlayerTwo.Name;
    }

    [HttpPost("{id}/move")]
    public ActionResult<String> PlayGame(Guid id, string playerTwoMove )
    {
      var game = memory.GetGame(id);
      game.PlayerTwo.Move = playerTwoMove;
      game.Status = "PLAYER TWO MOVE";

      return "Game ID" + game.GameID.ToString()
        + "\n Game status: " + game.Status
        + "\n Player 1: " + game.PlayerOne.Name
        + "\n Player 2: " + game.PlayerTwo.Name;
    }

    [HttpGet("{id}")]
    public ActionResult<Game> GameStatus(Guid id)
    {
      var gameInPlay = memory.GetGame(id);
      var tempList =  memory.GetGames();

      if (tempList.Contains(gameInPlay))
      {

      }

      return gameInPlay;
    }
  }
}
