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

    public IEnumerable<Food> Get(string name)
    {
      string sql = "SELECT * FROM foods WHERE name = @name";
      return _db.Query<Food>(sql, new { name });
    }

    public IEnumerable<Food> GetbyPhase()
  }
}