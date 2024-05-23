using Portfolio.Api.Contracts;

namespace Projects.Api.Endpoints;

public static class ProjectsEndpoints {
  const string GetProjectEndpointName = "GetProject";

  private static readonly List<ProjectContract> projects = [
    new (1, "Project 1", "This is my first project", "image url")
  ];

  public static RouteGroupBuilder MapProjectsEndpoints(this WebApplication app) {

    var group = app.MapGroup("projects").WithParameterValidation();
    
    // GET /projects
    group.MapGet("/", () => projects);

    // GET /projects/1
    group.MapGet("/{id}", (int id) => {
      
        ProjectContract ? project = projects.Find(project => project.Id == id);

        return project is null ? Results.NotFound() : Results.Ok(project);
      })
      .WithName(GetProjectEndpointName);

    // POST /projects
    group.MapPost("/", (CreateProjectContract newProject) => {

      ProjectContract project = new(
        projects.Count + 1,
        newProject.Name,
        newProject.Description,
        newProject.ImageUrl
      );

      projects.Add(project);

      return Results.CreatedAtRoute(GetProjectEndpointName, new { id = project.Id }, project);
    });

    // PUT /projects
    group.MapPut("/{id}", (int id, UpdateProjectContract UpdatedProject) => {

      var index = projects.FindIndex(project => project.Id == id);

      if (index == -1) {
        return Results.NotFound();
      }

      projects[index] = new ProjectContract(
        id,
        UpdatedProject.Name,
        UpdatedProject.Description,
        UpdatedProject.ImageUrl
      );

      return Results.NoContent();
    });

    //DELETE /projects/1
    group.MapDelete("/{id}", (int id) => {

      projects.RemoveAll((project) => project.Id == id);

      return Results.NoContent();
    });

    return group;
  }
}