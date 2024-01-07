using BlazorEcommerce.Client.Services.CartService;
using BlazorEcommerce.Server.Data;
using BlazorEcommerce.Server.Migrations;
using BlazorEcommerce.Shared;
using System.Security.Claims;

namespace BlazorEcommerce.Server.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;
        private readonly ICartService _cartService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderService(DataContext context,
            ICartService cartService,
            IHttpContextAccessor httpcontextAccessor)
        {
            _context = context;
            _cartService = cartService;
            _httpContextAccessor = httpcontextAccessor;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public Task<ServiceResponse<bool>> PlaceOrder()
        {
            throw new NotImplementedException();
        }
    }
}
