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
  }
}