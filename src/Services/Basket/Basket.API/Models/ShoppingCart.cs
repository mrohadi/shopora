namespace Basket.API.Models;

/// <summary>
/// 
/// </summary>
public class ShoppingCart
{
    public string UserName { get; set; } = default!;

    public List<ShoppingCartItem> Items { get; set; } = [];

    public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);

    public ShoppingCart(string userName)
    {
        UserName = userName;
    }

    // Required for mapping
    public ShoppingCart()
    {
    }
}