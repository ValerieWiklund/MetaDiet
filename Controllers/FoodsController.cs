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
    public ActionResult<IEnumerable<Models.Food>> Get()
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

    [Authorize]
    [HttpGet("user")]
    public ActionResult<IEnumerable<Food>> GetByUser()
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_fs.GetByUser(userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPost]
    public ActionResult<Food> Create([FromBody] Food newFood)
    {
      try
      {
        newFood.UserId = HttpContext.User.FindFirstValue("Id");
        return Ok(_fs.Create(newFood));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}/view")]

    public ActionResult<Food> EditViewCount([FromBody] Food editFood, int id)
    {
      try
      {
        editFood.Id = id;
        return Ok(_fs.EditViewCount(editFood));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPut("{id}")]

    public ActionResult<Food> Edit([FromBody] Food editFood, int id)
    {
      try
      {
        //   id = editFood.Id;
        return Ok(_fs.Edit(editFood));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
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