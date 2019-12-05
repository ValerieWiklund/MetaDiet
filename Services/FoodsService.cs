using System;
using System.Collections.Generic;
using MetaDiet.Models;
using MetaDiet.Repositories;

namespace MetaDiet.Services
{
  public class FoodsService
  {
    private readonly FoodsRepository _repo;
    public FoodsService(FoodsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Food> Get()
    {
      return _repo.Get();
    }

    public Food Get(string name)
    {
      Food exists = _repo.Get(name);
      if (exists == null) { throw new Exception("Invalid Name"); }
      return exists;
    }

    public IEnumerable<Food> GetByCategory(string category)
    {
      return _repo.GetByCategory(category);
    }

    public Food Create(Food newFood)
    {
      int id = _repo.Create(newFood);
      newFood.Id = id;
      return newFood;
    }

    public Food Edit(Food editFood)
    {
      Food food = _repo.Get(editFood.Id);
      if (food == null) { throw new Exception("Invalid Id"); }
      food.Name = editFood.Name;
      food.Description = editFood.Description;
      food.Category = editFood.Category;
      food.Phase1 = editFood.Phase1;
      food.Phase2 = editFood.Phase2;
      food.Phase3 = editFood.Phase3;
      food.ServingNum = editFood.ServingNum;
      food.SizeDescription = editFood.SizeDescription;
      _repo.Edit(food);
      return food;
    }

    public string Delete(int id)
    {
      Food exists = _repo.Get(id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      _repo.Delete(id);
      return "Successfully Deleted";
    }
  }
}