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
    private readonly IInGameMemory memory; // Connect controler with in memory repository

    public GameController(IInGameMemory memory)
    {
      this.memory = memory;
    }

    [HttpPost]
    public ActionResult<String> CreateGame(String playerOneName, string playerOneMove)
    {
      // new instance of game 
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

      memory.CreateGame(game); //save game in List

      // User feedback
      return "Game Id: " + game.GameID.ToString()
        + "\n Game status: " + game.Status
        + "\n Player 1: " + game.PlayerOne.Name;
    }

    [HttpPost("{id}/join")]
    public ActionResult<String> JoinGame(Guid id, string playerTwoName)
    {
      var game = memory.GetGame(id); // get game from list
      game.PlayerTwo = new Player
      {
        Name = playerTwoName
      };
      game.Status = "JOINING";

      //user feedback
      return "Game ID: " + game.GameID.ToString()
        + "\n Game status: " + game.Status
        + "\n Player 1: " + game.PlayerOne.Name
        + "\n Player 2: " + game.PlayerTwo.Name;
    }

    [HttpPost("{id}/move")]
    public ActionResult<String> PlayGame(Guid id, string playerTwoMove)
    {
      var game = memory.GetGame(id);
      game.PlayerTwo.Move = playerTwoMove;
      game.Status = "PLAYER TWO MOVE";

      //User feedback
      return "Game ID: " + game.GameID.ToString()
        + "\n Game status: " + game.Status
        + "\n Player 1: " + game.PlayerOne.Name
        + "\n Player 2: " + game.PlayerTwo.Name;
    }

    [HttpGet("{id}")]
    public ActionResult<Game> GameStatus(Guid id)
    {
      Game gameInPlay = memory.GetGame(id);

      //fix format and make players move easier to acces with new varibles 
      var p1Move = gameInPlay.PlayerOne.Move.ToUpper();
      var p2Move = gameInPlay.PlayerTwo.Move.ToUpper();

      // check if game exist, then do game logic
      if (gameInPlay != null)
      {
        if (p1Move == "ROCK")
        {
          if (p2Move == "ROCK")
          {
            gameInPlay.Status = "GAME TIE";
          }

          if (p2Move == "PAPER")
          {
            gameInPlay.Status = gameInPlay.PlayerTwo.Name + " WINS";
          }

          if (p2Move == "SCISSORS")
          {
            gameInPlay.Status = gameInPlay.PlayerOne.Name + " WINS";
          }
        }
        if (p1Move == "PAPER")
        {
          if (p2Move == "ROCK")
          {
            gameInPlay.Status = gameInPlay.PlayerOne.Name + " WINS";
          }

          if (p2Move == "PAPER")
          {
            gameInPlay.Status = "GAME TIE";
          }

          if (p2Move == "SCISSORS")
          {
            gameInPlay.Status = gameInPlay.PlayerTwo.Name + " WINS";
          }
        }

        if (p1Move == "SCISSORS")
        {
          if (p2Move == "ROCK")
          {
            gameInPlay.Status = gameInPlay.PlayerTwo.Name + " WINS";
          }

          if (p2Move == "PAPER")
          {
            gameInPlay.Status = gameInPlay.PlayerOne.Name + " WINS";
          }

          if (p2Move == "SCISSORS")
          {
            gameInPlay.Status = "GAME TIE";
          }
        }
          return gameInPlay;
      }
      gameInPlay.Status = "GAME NOT FOUND";
      return gameInPlay;
    }
  }
}
