using BlazorEcommerce.Shared;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;

namespace BlazorEcommerce.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _http;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public CartService(ILocalStorageService localStorage, HttpClient http, AuthenticationStateProvider authenticationStateProvider)
        {
            _localStorage = localStorage;
            _http = http;
            _authenticationStateProvider = authenticationStateProvider;
        }


        public event Action OnChanged;

        public async Task AddToCart(CartItem cartItem)
        {
            if((await _authenticationStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated)
            {
                Console.WriteLine("user is authenticated");
            }
            else
            {
                Console.WriteLine("user is not authenticated");
            }

            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (cart == null) 
            {
                cart = new List<CartItem>();
            }

            var sameItem = cart.Find(x => x.ProductId == cartItem.ProductId 
            && x.ProductTypeId == cartItem.ProductTypeId);
            if (sameItem == null) 
            {
                cart.Add(cartItem);
            }
            else
            {
                sameItem.Quantity += cartItem.Quantity;
            }

            await _localStorage.SetItemAsync("cart", cart);
            OnChanged.Invoke();
        }

        public async Task<List<CartItem>> GetCartItems()
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                cart = new List<CartItem>();
            }

            return cart;
        }

        public async Task<List<CartProductRespose>> GetCartProducts()
        {
            var cartItems = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            var response = await _http.PostAsJsonAsync("api/cart/products", cartItems);
            var cartProducts =
                await response.Content.ReadFromJsonAsync<ServiceResponse<List<CartProductRespose>>>();
            return cartProducts.Data;
        }

        public async Task RemoveProductFromCart(int productId, int productTypeId)
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                return;
            }

            var cartItem = cart.Find(x => x.ProductId == productId
                && x.ProductTypeId == productTypeId);
            if(cartItem != null)
            {
                cart.Remove(cartItem);
                await _localStorage.SetItemAsync("cart", cart);
                OnChanged.Invoke();
            }
        }

        public async Task UpdateQuantity(CartProductRespose product)
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                return;
            }

            var cartItem = cart.Find(x => x.ProductId == product.ProductId
                && x.ProductTypeId == product.ProductTypeId);
            if (cartItem != null)
            {
                cartItem.Quantity = product.Quantity;
                await _localStorage.SetItemAsync("cart", cart);
            }
        }
    }
}
