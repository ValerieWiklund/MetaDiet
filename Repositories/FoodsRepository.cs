using System.Data;
using System;
using System.Collections.Generic;
using Dapper;
using MetaDiet.Models;

namespace MetaDiet.Repositories
{
  public class FoodsRepository
  {
    private readonly IDbConnection _db;
    public FoodsRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Food> Get()
    {
      string sql = "SELECT * FROM foods";
      return _db.Query<Food>(sql);
    }

    public Food Get(int id)
    {
      string sql = "SELECT * FROM keeps WHERE id = @id";
      return _db.QueryFirstOrDefault<Food>(sql, new { id });
    }

    public Food Get(string name)
    {
      string sql = "SELECT * FROM foods WHERE name = @name";
      return _db.QueryFirstOrDefault<Food>(sql, new { name });
    }

    public IEnumerable<Food> GetByCategory(string category)
    {
      string sql = "SELECT * FROM foods WHERE category = @category";
      return _db.Query<Food>(sql, new { category });
    }

    public int Create(Food newFood)
    {
      string sql = @"
        INSERT INTO foods 
        (name, description, category, phase1, phase2, phase3, servingNum, sizeDescription)
        VALUES
        (@Name, @Description, @Category, @Phase1, @Phase2, @Phase3, @ServingNum, @SizeDescription);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newFood);
    }
    public void Edit(Food food)
    {
      string sql = @"
                UPDATE foods
                SET
                    name = @Name,
                    description = @Description,
                    category = @Category,
                    phase1 = @Phase1,
                    phase2 = @Phase2,
                    phase3 = @Phase3,
                    servingNum = @ServingNum,
                    sizeDescription = @SizeDescription
                WHERE id = @Id";
      _db.Execute(sql, food);
    }

    public void Delete(int id)
    {
      string sql = "DELETE FROM foods WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}