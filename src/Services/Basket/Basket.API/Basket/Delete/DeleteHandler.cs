namespace Basket.API.Basket.Delete;

public class DeleteBasketCommandHandler(IBasketRepository repository)
    : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
{
    public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
    {
        // TODO: delete basket from database and cache       
        await repository.DeleteBasket(command.UserName, cancellationToken);

        return new DeleteBasketResult(true);
    }
}

/// <summary>
/// 
/// </summary>
/// <param name="UserName"></param>
/// <returns></returns>
public record DeleteBasketCommand(string UserName) : ICommand<DeleteBasketResult>;

/// <summary>
/// 
/// </summary>
/// <param name="IsSuccess"></param>
/// <returns></returns>
public record DeleteBasketResult(bool IsSuccess);

/// <summary>
/// 
/// </summary>
public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
{
    public DeleteBasketCommandValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required");
    }
}
