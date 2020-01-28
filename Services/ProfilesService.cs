using System;
using System.Collections.Generic;
using MetaDiet.Models;
using MetaDiet.Repositories;

namespace MetaDiet.Services
{
  public class ProfilesService
  {
    private readonly ProfilesRepository _repo;
    public ProfilesService(ProfilesRepository repo)
    {
      _repo = repo;
    }

    public Profile Get(string userId)
    {
      return _repo.Get(userId);
    }

    public Profile Get(int id)
    {
      Profile exists = _repo.Get(id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      return exists;
    }

    public Profile Create(Profile newProfile)
    {
      int id = _repo.Create(newProfile);
      newProfile.Id = id;
      return newProfile;
    }

    public Profile Edit(Profile editProfile)
    {
      Profile profile = _repo.Get(editProfile.Id);
      if (profile == null) { throw new Exception("Invalid Id"); }
      profile.DOB = editProfile.DOB;
      profile.StartDate = editProfile.StartDate;
      profile.Height = editProfile.Height;
      profile.StartWeight = editProfile.StartWeight;
      profile.GoalWeight = editProfile.GoalWeight;
      profile.Gender = editProfile.Gender;
      _repo.Edit(profile);
      return profile;
    }

    public string Delete(int id)
    {
      Profile exists = _repo.Get(id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      _repo.Delete(id);
      return "Successfully Deleted";
    }

  }
}