namespace Basket.API.Data;

/// <summary>
/// 
/// </summary>
public interface IBasketRepository
{
    Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellation = default);
    Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellation = default);
    Task<bool> DeleteBasket(string userName, CancellationToken cancellation = default);
}