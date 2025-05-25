
namespace Basket.API.Data;

/// <summary>
/// 
/// </summary>
/// <param name="session"></param> <summary>
/// 
/// </summary>
public class BasketRespository(IDocumentSession session) : IBasketRepository
{
    public async Task<bool> DeleteBasket(string userName, CancellationToken cancellation = default)
    {
        session.Delete<ShoppingCart>(userName);
        await session.SaveChangesAsync(cancellation);
        return true;
    }

    public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellation = default)
    {
        var baskets = await session.LoadAsync<ShoppingCart>(userName, cancellation) ??
            throw new BasketNotFoundException(userName);

        return baskets;
    }

    public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellation = default)
    {
        session.Store(basket);
        await session.SaveChangesAsync(cancellation);
        return basket;
    }
}