using System.Data;
using Dapper;
using Metadiet.Models;

namespace Metadiet.Repositories
{
  public class AccountRepository
  {

    IDbConnection _db;

    public AccountRepository(IDbConnection db)
    {
      _db = db;
    }

    //REGISTER
    public void Register(User user)
    {
      //generate the user id
      //HASH THE PASSWORD
      string sql = @"
                INSERT INTO users 
                (id, username, email, hash, dob, height, startweight, goalweight, gender, startdate)
                VALUES 
                (@id, @username, @email, @Hash, @DOB, @Height, @StartWeight, @GoalWeight, @Gender, @StartDate)";
      _db.Execute(sql, user);
    }

    internal User GetUserByEmail(string email)
    {
      string sql = "SELECT * FROM users WHERE email = @email";
      return _db.QueryFirstOrDefault<User>(sql, new { email });
    }

    internal User GetUserById(string id)
    {
      string sql = "SELECT * FROM users WHERE id = @id";
      return _db.QueryFirstOrDefault<User>(sql, new { id });
    }

    public void Edit(User user)
    {
      string sql = @"
                UPDATE users
                SET
                    dob = @DOB,
                    height = @Height,
                    startweight = @StartWeight,
                    goalweight = @GoalWeight,
                    gender = @Gender,
                    startdate = @StartDate
                WHERE id = @Id";
      _db.Execute(sql, user);
    }



  }
}