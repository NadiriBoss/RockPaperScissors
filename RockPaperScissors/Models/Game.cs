using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissors.Models
{
  public class Game
  {

    public Guid GameID { get; set; }
    public String Status { get; set; }

    public Player PlayerOne { get; set; }

    public Player PlayerTwo { get; set; }
  }

}
