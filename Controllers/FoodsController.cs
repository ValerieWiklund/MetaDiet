using System;
using System.Collections.Generic;
using MetaDiet.Models;
using MetaDiet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MetaDiet.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]

  public class FoodsController : ControllerBase
  {
    private readonly FoodsService _fs;
    public FoodsController(FoodsService fs)
    {
      _fs = fs;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Food>> Get()
    {
      try
      {
        return Ok(_fs.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Food> Get(int id)
    {
      try
      {
        return Ok(_fs.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{name}")]
    public ActionResult<Food> Get(string name)
    {
      try
      {
        return Ok(_fs.Get(name));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{category}")]
    public ActionResult<IEnumerable<Food>> GetByCategory(string category)
    {
      try
      {
        // string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_fs.GetByCategory(category));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // [Authorize]
    [HttpPost]
    public ActionResult<Food> Create([FromBody] Food newFood)
    {
      try
      {
        return Ok(_fs.Create(newFood));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    // [Authorize]
    [HttpPut("{id}")]

    public ActionResult<Food> Edit([FromBody] Food editFood, int id)
    {
      try
      {
        id = editFood.Id;
        return Ok(_fs.Edit(editFood));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // [Authorize]
    [HttpDelete("{id}")]

    public ActionResult<Food> Delete(int id)
    {
      try
      {
        return Ok(_fs.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}