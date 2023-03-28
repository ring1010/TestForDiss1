using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using TestForDiss.Data;
using webapi.Models;
using Newtonsoft.Json;

namespace webapi.Controllers;

public static class PlantsEndpoints
{
    public static void MapPlantsEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Plants").WithTags(nameof(Plants));

        group.MapGet("/", async (MyDbContext db) =>
        {
           // List<Plants> plants = new List<Plants>();
            List<Plants> plants =  db.Plants.ToList();
            var json = JsonConvert.SerializeObject(plants);

            return json;
         
        })
        .WithName("Plants")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Plants>, NotFound>> (int id, MyDbContext db) =>
        {
            return await db.Plants.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Plants model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetPlantsById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Plants plants, MyDbContext db) =>
        {
            var affected = await db.Plants
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Id, plants.Id)
                  .SetProperty(m => m.Name, plants.Name)
                  .SetProperty(m => m.CountryId, plants.CountryId)
                  .SetProperty(m => m.Description, plants.Description)
                  .SetProperty(m => m.TimeZone, plants.TimeZone)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdatePlants")
        .WithOpenApi();

        group.MapPost("/", async (Plants plants, MyDbContext db) =>
        {
            db.Plants.Add(plants);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Plants/{plants.Id}",plants);
        })
        .WithName("CreatePlants")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, MyDbContext db) =>
        {
            var affected = await db.Plants
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeletePlants")
        .WithOpenApi();
    }
}
