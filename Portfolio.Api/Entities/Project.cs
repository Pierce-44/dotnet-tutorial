
namespace Portfolio.Api.Entities;

public class Project {
  public int Id { get; set; }

  public required string Name { get; set; }

  public int TypeId { get; set; }

  public ProjectType? ProjectType { get; set; }

  public DateOnly CreatedDate { get; set; }
}