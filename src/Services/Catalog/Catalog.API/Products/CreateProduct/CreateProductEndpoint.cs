namespace Catalog.API.Products.CreateProduct;

/// <summary>
/// 
/// </summary> <summary>
/// 
/// </summary>
public class CreateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products", async (CreateProductRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateProductCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateProductResponse>();
            return Results.Created($"/products/{response.Id}", response);
        })
        .WithName("CreateProduct")
        .Produces<CreateProductResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Product")
        .WithDescription("Create Product");
    }
}

/// <summary>
/// Create product endpoint request body
/// </summary>
/// <param name="Name">Name of the product</param>
/// <param name="Category">Category of the product</param>
/// <param name="Description">Description of the product</param>
/// <param name="ImageFile">Image file of the product</param>
/// <param name="Price">Price of the product</param>
public record CreateProductRequest(
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price
);

/// <summary>
/// Create product response body
/// </summary>
/// <param name="Id"></param> <summary>
/// </summary>
public record CreateProductResponse(Guid Id);