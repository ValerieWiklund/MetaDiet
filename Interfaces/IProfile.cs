using System;

namespace MetaDiet.Interfaces
{
  public interface IProfile
  {
    int Id { get; set; }
    DateTime DOB { get; set; }
    DateTime StartDate { get; set; }
    decimal Height { get; set; }
    int StartWeight { get; set; }
    int GoalWeight { get; set; }
    char Gender { get; set; }
    string UserId { get; set; }

  }
}