
using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.GetProductByCategory;

public record GetProductsByCategoryReponse(IEnumerable<Product> Products);
public class GetProductsByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{category}", async (string category, ISender sender) =>
        {
            var result = await sender.Send(new GetProductByCategoryQuery(category));
            var response = result.Adapt<GetProductsByCategoryReponse>();
            return Results.Ok(response);
        })
        .WithName("GetProductsByCategory")
        .Produces<CreateProductResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("GetProductsByCategory")
        .WithDescription("GetProductsByCategory");
    }
}