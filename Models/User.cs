using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Metadiet.Models
{

  public class UserSignIn // HELPER MODEL
  {
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }
  }
  public class UserRegistration // HELPER MODEL
  {

    [Required]
    public string Username { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }
  }

  public class User
  {
    public string Id { get; set; }
    public string Username { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public string Hash { get; set; }
    public int Height { get; set; }
    [Required]
    public DateTime Startdate { get; set; }
    public DateTime dob { get; set; }
    [Required]
    public int startweight { get; set; }
    [Required]
    public int goalweight { get; set; }
    public string gender { get; set; }
    internal ClaimsPrincipal _principal { get; private set; }

    internal void SetClaims()
    {
      var claims = new List<Claim>
            {
                new Claim("Id", Id), //req.session.uid = id
                new Claim(ClaimTypes.Email, Email),
                new Claim(ClaimTypes.Name, Username)
            };
      var userIdentity = new ClaimsIdentity(claims, "login");
      _principal = new ClaimsPrincipal(userIdentity);
    }
  }
}