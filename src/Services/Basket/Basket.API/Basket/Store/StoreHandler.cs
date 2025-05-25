namespace Basket.API.Basket.Store;

/// <summary>
/// 
/// </summary>
/// <param name="repository"></param> <summary>
/// 
/// </summary>
public class StoreBasketCommandHandler(IBasketRepository repository)
    : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellation)
    {
        // await DeductDiscount(command.Cart, cancellationToken);

        await repository.StoreBasket(command.Cart, cancellation);
        //TODO: 

        return new StoreBasketResult(command.Cart.UserName);
    }

    // private async Task DeductDiscount(ShoppingCart cart, CancellationToken cancellationToken)
    // {
    //     // Communicate with Discount.Grpc and calculate lastest prices of products into sc
    //     foreach (var item in cart.Items)
    //     {
    //         var coupon = await discountProto.GetDiscountAsync(new GetDiscountRequest { ProductName = item.ProductName }, cancellationToken: cancellationToken);
    //         item.Price -= coupon.Amount;
    //     }
    // }
}

/// <summary>
/// 
/// </summary>
/// <param name="Cart"></param>
/// <returns></returns>
public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;

/// <summary>
/// 
/// </summary>
/// <param name="UserName"></param>
/// <returns></returns>
public record StoreBasketResult(string UserName);

/// <summary>
/// 
/// </summary>
public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommandValidator()
    {
        RuleFor(x => x.Cart).NotNull().WithMessage("Cart can not be null");
        RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("UserName is required");
    }
}
