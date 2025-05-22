
namespace Catalog.API.Products.GetProducts;

public class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async ([AsParameters] GetProductsRequest request, ISender sender) =>
        {
            var query = request.Adapt<GetProductQuery>();
            var products = await sender.Send(query);
            var response = products.Adapt<GetProductsResponse>();
            return Results.Ok(response);
        })
        .WithName("GetProducts")
        .Produces<GetProductResult>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Products")
        .WithDescription("Get Products");
    }
}

public record GetProductsRequest(int? PageNumber = 1, int? PageSize = 10);

/// <summary>
/// 
/// </summary>
/// <param name="Products"></param> <summary>
/// 
/// </summary>
/// <param name="Products"></param>
/// <returns></returns>
public record GetProductsResponse(IEnumerable<Product> Products);