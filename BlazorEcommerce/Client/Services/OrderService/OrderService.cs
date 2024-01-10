using BlazorEcommerce.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;

namespace BlazorEcommerce.Client.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly NavigationManager _navigationManager;
        private readonly HttpClient _http;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public OrderService(HttpClient http,
            AuthenticationStateProvider authenticationStateProvider,
            NavigationManager navigationManager)
        {
            _http = http;
            _authenticationStateProvider = authenticationStateProvider;
            _navigationManager = navigationManager;
        }

        public async Task<List<OrderOverviewResponse>> GetOrders()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<OrderOverviewResponse>>>("api/order");

            return result.Data;
        }

        public async Task PlaceOrder()
        {
            if( await IsUserAuthenticated() )
            {
                await _http.PostAsync("api/order", null);
            }
            else
            {
                _navigationManager.NavigateTo("login");
            }
        }

        private async Task<bool> IsUserAuthenticated()
        {
            return (await _authenticationStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        }

    }
}
