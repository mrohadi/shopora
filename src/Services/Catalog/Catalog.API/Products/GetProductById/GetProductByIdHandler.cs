
namespace Catalog.API.Products.GetProductById;

/// <summary>
/// 
/// </summary>
/// <param name="session"></param>
/// <param name="logger"></param> <summary>
/// 
/// </summary>
/// <typeparam name="GetProductByIdQueryHandler"></typeparam>
internal class GetProductByIdQueryHandler(IDocumentSession session)
    : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(query.Id, cancellationToken) ?? throw new ProductNotFoundException(query.Id);

        return new GetProductByIdResult(product);
    }
}

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param> <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <returns></returns>
public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;

/// <summary>
/// 
/// </summary>
/// <param name="Product"></param> <summary>
/// 
/// </summary>
/// <param name="Product"></param>
/// <returns></returns>
public record GetProductByIdResult(Product Product);