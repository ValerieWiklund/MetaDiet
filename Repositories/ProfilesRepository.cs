using System.Data;
using System.Collections.Generic;
using Dapper;
using MetaDiet.Models;

namespace MetaDiet.Repositories
{
  public class ProfilesRepository
  {
    private readonly IDbConnection _db;

    public ProfilesRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Profile> Get(string userId)
    {
      string sql = "SELECT * FROM profiles WHERE userId = @userId";
      return _db.Query<Profile>(sql, new { userId });
    }

    public int Create(Profile newProfile)
    {
      string sql = @"
    INSERT INTO profiles
    (dob, startdate, height, startweight, goalweight, gender, userId)
    VALUES
    (@DOB, @StartDate, @Height, @StartWeight, @GoalWeight, @Gender, @UserId);
    SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newProfile);
    }

    public void Edit(Profile profile)
    {
      string sql = @"
        UPDATE profiles
        SET 
        dob = @DOB,
        startdate - @StartDate,
        height = @Height,
        startweight = @StartWeight,
        goalweight = @GoalWeight, 
        gender = @Gender
        WHERE id = @Id";
      _db.Execute(sql, profile);
    }

    public void Delete(int id)
    {
      string sql = "DELETE FROM profiles WHERE id = @Id";
      _db.Execute(sql, new { id });
    }

  }
}