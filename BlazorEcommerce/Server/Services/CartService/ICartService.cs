namespace BlazorEcommerce.Server.Services.CartService
{
    public interface ICartService
    {
        event Action OnChanged;
        Task AddCartItem(CartItem cartItem);
    }
}
