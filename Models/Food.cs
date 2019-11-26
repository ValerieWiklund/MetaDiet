using MetaDiet.Interfaces;

namespace MetaDiet.Models
{
  public class Food : IFood
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public bool Phase1 { get; set; }
    public bool Phase2 { get; set; }
    public bool Phase3 { get; set; }
    public int ServingNum { get; set; }
    public string SizeDescription { get; set; }
  }
}