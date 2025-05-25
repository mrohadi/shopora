
namespace Basket.API.Basket.Get;

public class GetBasketEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/baskets/{userName}", async (string userName, ISender sender) =>
        {
            var result = await sender.Send(new GetBasketQuery(userName));

            var respose = result.Adapt<GetBasketResponse>();

            return Results.Ok(respose);
        });
    }
}

//public record GetBasketRequest(string UserName); 

public record GetBasketResponse(ShoppingCart Cart);
