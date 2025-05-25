namespace Basket.API.Basket.Get;

/// <summary>
/// 
/// </summary>
public class GetBasketQueryHandler(IBasketRepository repository)
    : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellation)
    {
        var basket = await repository.GetBasket(query.UserName, cancellation);

        return new GetBasketResult(basket);
    }
}

/// <summary>
/// 
/// </summary>
/// <param name="UserName"></param>
/// <returns></returns>
public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;

/// <summary>
/// 
/// </summary>
/// <param name="Cart"></param>
/// <returns></returns>
public record GetBasketResult(ShoppingCart Cart);
