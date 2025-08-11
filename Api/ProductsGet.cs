using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System.Threading.Tasks;

namespace Api;

public class ProductsGet
{
    private readonly IProductData productData;

    //Constructor to inject the product data dependency
    public ProductsGet(IProductData productData)
    {
        this.productData = productData;
    }

    // Function to handle HTTP GET requests for products
    [FunctionName("ProductsGet")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "products")] HttpRequest req)
    {
        var products = await productData.GetProducts();
        return new OkObjectResult(products);
    }
}