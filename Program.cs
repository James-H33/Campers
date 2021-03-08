using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Campers.Services;
using Campers.Services.Interfaces;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Campers.Security;


namespace Campers
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddBlazoredLocalStorage();

            builder.Services.AddScoped<IBaseHttp, BaseHttp>();
            builder.Services.AddScoped<ICampgroundService, CampgroundService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<IStateService, StateService>();
            builder.Services.AddScoped<IUserProfileService, UserProfileService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<ISignupService, SignupService>();
            builder.Services.AddScoped<AuthenticationStateProvider>(serviceProvider =>
            {
                var ups = serviceProvider.GetRequiredService<IUserProfileService>();
                return new CampersAuthenticationStateProvider((UserProfileService)ups);
            });

            await builder.Build().RunAsync();
        }
    }
}
