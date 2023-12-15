namespace BlazorEcommerce.Server.Services.CartService
{
    public interface ICartService
    {
       Task<ServiceResponse<List<CartProductRespose>>> GetCartProducts(List<CartItem> cartItems);
    }
}
