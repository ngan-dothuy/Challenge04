using System;
using Challenge03.Data;
using Challenge03.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Challenge03.Endpoints;

public static class CategoryEndpoint
{
    public static RouteGroupBuilder MapCategoryEndpoint(this WebApplication app)
    {
        var group = app.MapGroup("categories");
        group.MapGet("/", async (ProjectContext dbContext) => 
        await dbContext.Categories
                    .Select(category => category.ToDto())
                    .AsNoTracking()
                    .ToListAsync());
        return group;

    }
}
