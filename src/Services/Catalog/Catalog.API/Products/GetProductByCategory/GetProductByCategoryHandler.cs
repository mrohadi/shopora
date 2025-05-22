
namespace Catalog.API.Products.GetProductByCategory;

/// <summary>
/// 
/// </summary> <summary>
/// 
/// </summary>
internal class GetProductByCategoryQueryHandler(IDocumentSession session)
    : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>()
            .Where(p => p.Category.Contains(query.Category))
            .ToListAsync(cancellationToken);

        return new GetProductByCategoryResult(products);
    }
}

/// <summary>
/// 
/// </summary>
/// <param name="Category"></param> <summary>
/// 
/// </summary>
/// <param name="Category"></param>
/// <returns></returns>
public record GetProductByCategoryQuery(string Category) : IQuery<GetProductByCategoryResult>;

/// <summary>
/// 
/// </summary>
/// <param name="Products"></param> <summary>
/// 
/// </summary>
/// <param name="Products"></param>
/// <returns></returns>
public record GetProductByCategoryResult(IEnumerable<Product> Products);