
namespace Catalog.API.Products.DeleteProduct;

public class DeleteProductEndpoint() : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/products/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteProductCommand(id));

            var response = result.Adapt<DeleteProductResponse>();

            Results.Ok(response);
        });
    }
}

// public record DeleteProductRequest(Guid Id);

/// <summary>
/// 
/// </summary>
/// <param name="IsSuccess"></param>
/// <returns></returns>
public record DeleteProductResponse(bool IsSuccess);