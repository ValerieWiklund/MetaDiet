using System;
using Metadiet.Models;
using Metadiet.Repositories;

namespace Metadiet.Services
{
  public class AccountService
  {
    private readonly AccountRepository _repo;

    public User Register(UserRegistration creds)
    {
      User user = new User();
      user.Id = Guid.NewGuid().ToString();
      user.Email = creds.Email;
      user.Username = creds.Username;
      user.Hash = BCrypt.Net.BCrypt.HashPassword(creds.Password);

      _repo.Register(user);
      return user;
    }

    public User SignIn(UserSignIn creds)
    {
      User user = _repo.GetUserByEmail(creds.Email);
      if (user == null || !BCrypt.Net.BCrypt.Verify(creds.Password, user.Hash))
      {
        throw new Exception("Invalid Email or Password");
      }
      user.Hash = null;
      return user;
    }

    public User GetUserById(string Id)
    {
      User user = _repo.GetUserById(Id);
      if (user == null) { throw new Exception("Invalid Request"); }
      user.Hash = null;
      return user;
    }

    public AccountService(AccountRepository repo)
    {
      _repo = repo;
    }

    public User Edit(User editUser)
    {
      User user = _repo.GetUserById(editUser.Id);
      if (user == null) { throw new Exception("Invalid Id"); }
      user.Username = editUser.Username;
      user.DOB = editUser.DOB;
      user.Height = editUser.Height;
      user.Gender = editUser.Gender;
      user.StartWeight = editUser.StartWeight;
      user.GoalWeight = editUser.GoalWeight;
      user.StartDate = editUser.StartDate;
      _repo.Edit(user);
      return user;
    }

  }
}