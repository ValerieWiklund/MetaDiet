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

  }
}