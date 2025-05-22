
namespace Catalog.API.Products.DeleteProduct;

/// <summary>
/// j
/// </summary>
/// <param name="session"></param>
/// <param name="logger"></param> <summary>
/// 
/// </summary>
/// <typeparam name="DeleteProductCommandHandler"></typeparam>
internal class DeleteProductCommandHandler(IDocumentSession session)
    : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        session.Delete<Product>(command.Id);
        await session.SaveChangesAsync(cancellationToken);

        return new DeleteProductResult(true);
    }
}

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <returns></returns>
public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;

/// <summary>
/// 
/// </summary>
/// <param name="IsSuccess"></param>
/// <returns></returns>
public record DeleteProductResult(bool IsSuccess);

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty().WithMessage("Product ID is required");
    }
}