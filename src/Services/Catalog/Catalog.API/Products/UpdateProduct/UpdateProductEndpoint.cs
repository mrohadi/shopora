
namespace Catalog.API.Products.UpdateProduct;

public class UpdateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/products", async (UpdateProductRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateProductCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateProductResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateProduct")
        .Produces<UpdateProductResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Product")
        .WithDescription("Update Product");
    }
}

/// <summary>
/// 
/// </summary>
/// <param name="Name"></param>
/// <param name="Category"></param>
/// <param name="Description"></param>
/// <param name="ImageFile"></param>
/// <param name="Price"></param> <summary>
/// 
/// </summary>
/// <param name="Name"></param>
/// <param name="Category"></param>
/// <param name="Description"></param>
/// <param name="ImageFile"></param>
/// <param name="Price"></param>
/// <returns></returns>
public record UpdateProductRequest(
    Guid Id,
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price
);

/// <summary>
/// 
/// </summary>
/// <param name="IsSuccess"></param>
/// <returns></returns>
public record UpdateProductResponse(bool IsSuccess);