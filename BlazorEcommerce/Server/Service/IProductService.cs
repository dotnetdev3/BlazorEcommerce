namespace BlazorEcommerce.Server.Service
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProductsListAsync();
    }
}
