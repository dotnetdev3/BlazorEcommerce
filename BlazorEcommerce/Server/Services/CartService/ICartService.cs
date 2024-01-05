﻿using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Server.Services.CartService
{
    public interface ICartService
    {
       Task<ServiceResponse<List<CartProductRespose>>> GetCartProducts(List<CartItem> cartItems);
       Task<ServiceResponse<List<CartProductRespose>>> StoreCartItems(List<CartItem> cartItems);
       Task<ServiceResponse<int>> GetCartItemsCount();
       Task<ServiceResponse<List<CartProductRespose>>> GetDbCartProducts();
       Task<ServiceResponse<bool>> AddToCart(CartItem cartItem);
       Task<ServiceResponse<bool>> UpdateQuantity(CartItem cartItem);
    }
}
