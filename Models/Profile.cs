using System;
using MetaDiet.Interfaces;

namespace MetaDiet.Models
{
  public class Profile : IProfile
  {
    public int Id { get; set; }
    public DateTime DOB { get; set; }
    public DateTime StartDate { get; set; }
    public decimal Height { get; set; }
    public int StartWeight { get; set; }
    public int GoalWeight { get; set; }
    public char Gender { get; set; }
    public string UserId { get; set; }
  }
}