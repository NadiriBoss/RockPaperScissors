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
    public ActionResult<Game> CreateGame(String player1Name)
    {
      Game game = new Game();
      game.gameID = new Guid();

      return game;
    }

    [HttpPost("{id}/join")]
    public ActionResult<Game> JoinGame(String player2Name)
    {

      return 
    }

    [HttpPost("{id}/move")]
    public ActionResult<Game> PlayGame(String player2Name)
    {

      return
    }

    [HttpGet("{id}")]
    public ActionResult<Game> GameStatus()
    {


    }
  }
}
