namespace Portfolio.Api.Contracts;

public record class UpdateProjectContract(
    string Name, 
    string Description,
    string ImageUrl
);