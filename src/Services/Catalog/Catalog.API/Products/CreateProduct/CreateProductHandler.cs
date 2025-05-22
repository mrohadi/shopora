namespace Catalog.API.Products.CreateProduct;

/// <summary>
/// 
/// </summary> <summary>
/// 
/// </summary>
internal class CreateProductCommandHandler(IDocumentSession session)
: ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellation)
    {
        var product = new Product
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price,
        };
        session.Store(product);
        await session.SaveChangesAsync(cancellation);

        return new CreateProductResult(product.Id);
    }
}

/// <summary>
/// 
/// </summary>
/// <param name="Name"></param>
/// <param name="Category"></param>
/// <param name="Description"></param>
/// <param name="ImageFile"></param>
/// <param name="Price"></param> <summary>
/// 
/// </summary>
/// <param name="Name"></param>
/// <param name="Category"></param>
/// <param name="Description"></param>
/// <param name="ImageFile"></param>
/// <param name="Price"></param>
/// <returns></returns>
public record CreateProductCommand(
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price
) : ICommand<CreateProductResult>;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param> <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <returns></returns>
public record CreateProductResult(Guid Id);

/// <summary>
/// 
/// </summary> <summary>
/// 
/// </summary>
public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(p => p.Category).NotEmpty().WithMessage("Category is required");
        RuleFor(p => p.ImageFile).NotEmpty().WithMessage("Image File is required");
        RuleFor(p => p.Price).NotEmpty().WithMessage("Price is required");
    }
}