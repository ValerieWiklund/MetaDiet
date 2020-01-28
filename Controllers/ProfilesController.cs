
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

  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _ps;
    public ProfilesController(ProfilesService ps)
    {
      _ps = ps;
    }

    [Authorize]
    [HttpGet("{userId}")]
    public ActionResult<Profile> Get(string userId)
    {
      try
      {
        return Ok(_ps.Get(userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Profile> Get(int id)
    {
      try
      {
        return Ok(_ps.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpPost]

    public ActionResult<Profile> Create([FromBody] Profile newProfile)
    {
      try
      {
        newProfile.UserId = HttpContext.User.FindFirstValue("Id");
        return Ok(_ps.Create(newProfile));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }

}