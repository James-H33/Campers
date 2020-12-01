using Campers.Services;
using Campers.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Campers.Security
{
    public class CampersAuthenticationStateProvider : AuthenticationStateProvider
    {
        public UserProfileService _userProfileService;
        public CampersAuthenticationStateProvider(UserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var profile = await _userProfileService.GetProfile();

            if (profile.isLoggedIn()) 
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, profile.Username),
                }, "Authenticated User");

                var user = new ClaimsPrincipal(identity);

                return new AuthenticationState(user);
            }
            else 
            {
                return new AuthenticationState(new ClaimsPrincipal());
            }
        }

        public void MarkUserAsAuthenticated()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public void MarkUserAsUnAuthenticated()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
