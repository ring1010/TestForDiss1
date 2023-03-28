using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestForDiss.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
    }


public static class CountriesEndpoints
{
	public static void MapCountriesEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Countries").WithTags(nameof(Countries));

        group.MapGet("/", async (MyDbContext db) =>
        {
            return await db.Countries.ToListAsync();
        })
        .WithName("GetAllCountriess")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Countries>, NotFound>> (int id, MyDbContext db) =>
        {
            return await db.Countries.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Countries model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetCountriesById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Countries countries, MyDbContext db) =>
        {
            var affected = await db.Countries
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Id, countries.Id)
                  .SetProperty(m => m.Name, countries.Name)
                  .SetProperty(m => m.Description, countries.Description)
                  .SetProperty(m => m.Currency, countries.Currency)
                  .SetProperty(m => m.RegionsId, countries.RegionsId)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateCountries")
        .WithOpenApi();

        group.MapPost("/", async (Countries countries, MyDbContext db) =>
        {
            db.Countries.Add(countries);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Countries/{countries.Id}",countries);
        })
        .WithName("CreateCountries")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, MyDbContext db) =>
        {
            var affected = await db.Countries
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteCountries")
        .WithOpenApi();
    }
}}
