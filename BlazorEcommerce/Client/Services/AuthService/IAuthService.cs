﻿using BlazorEcommerce.Client.Shared;
using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(UserRegister request);
    }
}