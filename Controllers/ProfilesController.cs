
using MetaDiet.Services;
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



  }

}