namespace Basket.API.Basket.Delete;

/// <summary>
/// 
/// </summary>
public class DeleteBasketEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/baskets/{userName}", async (string userName, ISender sender) =>
        {
            var result = await sender.Send(new DeleteBasketCommand(userName));

            var response = result.Adapt<DeleteBasketResponse>();

            return Results.Ok(response);
        });
    }
}

//public record DeleteBasketRequest(string UserName);

/// <summary>
/// 
/// </summary>
/// <param name="IsSuccess"></param>
/// <returns></returns>
public record DeleteBasketResponse(bool IsSuccess);
