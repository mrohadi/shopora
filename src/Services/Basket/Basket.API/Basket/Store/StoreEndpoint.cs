namespace Basket.API.Basket.Store;

/// <summary>
/// 
/// </summary>
public class StoreBasketEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/baskets", async (StoreBasketRequest request, ISender sender) =>
        {
            var command = request.Adapt<StoreBasketCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<StoreBasketResponse>();

            return Results.Created($"/basket/{response.UserName}", response);
        });
    }
}

/// <summary>
/// 
/// </summary>
/// <param name="Cart"></param>
/// <returns></returns>
public record StoreBasketRequest(ShoppingCart Cart);

/// <summary>
/// 
/// </summary>
/// <param name="UserName"></param>
/// <returns></returns>
public record StoreBasketResponse(string UserName);
