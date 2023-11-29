namespace BlazorEcommerce.Server.Service
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProductsListAsync();

        Task<ServiceResponse<Product>> GetProductByIdAsync(int productId);
    }
}
