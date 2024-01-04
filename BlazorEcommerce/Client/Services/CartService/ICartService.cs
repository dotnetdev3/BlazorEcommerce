using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Services.CartService
{
    public interface ICartService
    {
        event Action OnChanged;
        Task AddToCart(CartItem cartItem);
        Task<List<CartProductRespose>> GetCartProducts();
        Task RemoveProductFromCart(int productId, int productTypeId);
        Task UpdateQuantity(CartProductRespose product);
        Task StoreCartItems(bool emptyLocalCart);
        Task GetCartItemsCount();
    }
}
