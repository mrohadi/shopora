
namespace Catalog.API.Products.GetProductById;

public class GetProductByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
        {
            var product = await sender.Send(new GetProductByIdQuery(id));
            var response = product.Adapt<GetProductByIdResponse>();
            return Results.Ok(product);
        })
        .WithName("GetProductById")
        .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Product By Id")
        .WithDescription("Get Product By Id");
    }
}

// public record GetProductByIdRequest()

/// <summary>
/// 
/// </summary>
/// <param name="Product"></param> <summary>
/// 
/// </summary>
/// <param name="Product"></param>
/// <returns></returns>
public record GetProductByIdResponse(Product Product);

