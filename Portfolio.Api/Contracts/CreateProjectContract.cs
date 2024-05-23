using System.ComponentModel.DataAnnotations;

namespace Portfolio.Api.Contracts;

public record class CreateProjectContract(
  [Required][StringLength(50)] string Name,
  [Required][StringLength(100)] string Description,
  [Required][StringLength(50)] string ImageUrl
);