
using System.Reflection;

namespace Catalog.API.Products.GetProductByCategory;

/// <summary>
/// 
/// </summary> <summary>
/// 
/// </summary>
public class GetProductByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{category}", async (string category, ISender sender) =>
        {
            var result = await sender.Send(new GetProductByCategoryQuery(category));
            var response = result.Adapt<GetProductByCategoryResponse>();
            return Results.Ok(response);
        });
        // .WithName("GetProductsByCategory")
        // .Produces<GetProductByCategoryResponse>(StatusCodes.Status200OK)
        // .ProducesProblem(StatusCodes.Status400BadRequest)
        // .WithSummary("Get Products By Category")
        // .WithDescription("Get Product By Category");
    }
}

// public record GetProductByCategoryRequest();

/// <summary>
/// 
/// </summary>
/// <param name="Products"></param> <summary>
/// 
/// </summary>
/// <param name="Products"></param>
/// <returns></returns>
public record GetProductByCategoryResponse(IEnumerable<Product> Products);