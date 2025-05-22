namespace Catalog.API.Products.GetProducts;

internal class GetProductsQueryHandler(IDocumentSession session)
    : IQueryHandler<GetProductQuery, GetProductResult>
{
    public async Task<GetProductResult> Handle(GetProductQuery query, CancellationToken cancellation)
    {
        var products = await session.Query<Product>()
            .ToPagedListAsync(query.PageNumber ?? 1, query.PageSize ?? 10, cancellation);

        return new GetProductResult(products);
    }
}

/// <summary>
/// 
/// </summary> <summary>
/// 
/// </summary>
/// <returns></returns>
public record GetProductQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetProductResult>;

/// <summary>
/// 
/// </summary>
/// <param name="Products"></param>
/// <returns></returns>
public record GetProductResult(IEnumerable<Product> Products);