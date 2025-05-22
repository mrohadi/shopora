namespace Catalog.API.Exceptions;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param> <summary>
/// 
/// </summary>
public class ProductNotFoundException(Guid Id) : NotFoundException("Product", Id)
{
}