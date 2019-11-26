namespace MetaDiet.Interfaces
{
  public interface IFood
  {
    int Id { get; set; }
    string Name { get; set; }
    string Description { get; set; }
    string Category { get; set; }
    bool Phase1 { get; set; }
    bool Phase2 { get; set; }
    bool Phase3 { get; set; }
    int ServingNum { get; set; }
    string SizeDescription { get; set; }
  }
}