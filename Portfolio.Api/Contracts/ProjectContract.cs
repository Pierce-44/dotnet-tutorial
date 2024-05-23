namespace Portfolio.Api.Contracts;

public record class ProjectContract(
  int Id, 
  string Name, 
  string Description,
  string ImageUrl
  );