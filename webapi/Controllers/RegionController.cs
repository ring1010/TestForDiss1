﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestForDiss.Data;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {

    }
    public static class RegionsEndpoints
    {
        public static void MapRegionsEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/Regions").WithTags(nameof(Regions));

            group.MapGet("/", async (MyDbContext db) =>
            {
                return await db.Regions.ToListAsync();
            })
            .WithName("GetAllRegionss")
            .WithOpenApi();

            group.MapGet("/{id}", async Task<Results<Ok<Regions>, NotFound>> (int id, MyDbContext db) =>
            {
                return await db.Regions.AsNoTracking()
                    .FirstOrDefaultAsync(model => model.Id == id)
                    is Regions model
                        ? TypedResults.Ok(model)
                        : TypedResults.NotFound();
            })
            .WithName("GetRegionsById")
            .WithOpenApi();

            group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Regions regions, MyDbContext db) =>
            {
                var affected = await db.Regions
                    .Where(model => model.Id == id)
                    .ExecuteUpdateAsync(setters => setters
                      .SetProperty(m => m.Id, regions.Id)
                      .SetProperty(m => m.Name, regions.Name)
                      .SetProperty(m => m.Description, regions.Description)
                    );

                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("UpdateRegions")
            .WithOpenApi();

            group.MapPost("/", async (Regions regions, MyDbContext db) =>
            {
                db.Regions.Add(regions);
                await db.SaveChangesAsync();
                return TypedResults.Created($"/api/Regions/{regions.Id}", regions);
            })
            .WithName("CreateRegions")
            .WithOpenApi();

            group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, MyDbContext db) =>
            {
                var affected = await db.Regions
                    .Where(model => model.Id == id)
                    .ExecuteDeleteAsync();

                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("DeleteRegions")
            .WithOpenApi();
        }
    }
}
