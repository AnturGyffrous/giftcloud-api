using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IDL.Giftcloud.Api.OpenIddict.Models;
using IDL.Giftcloud.Api.OpenIddict.Resolvers;
using IDL.Giftcloud.Api.OpenIddict.Stores;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace IDL.Giftcloud.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddOpenIddict()
                .AddCore(options =>
                {
                    options.SetDefaultApplicationEntity<OpenIddictApplication>()
                        .SetDefaultAuthorizationEntity<OpenIddictAuthorization>()
                        .SetDefaultScopeEntity<OpenIddictScope>()
                        .SetDefaultTokenEntity<OpenIddictToken>();

                    options.ReplaceApplicationStoreResolver<OpenIddictApplicationStoreResolver>()
                        .ReplaceAuthorizationStoreResolver<OpenIddictAuthorizationStoreResolver>()
                        .ReplaceScopeStoreResolver<OpenIddictScopeStoreResolver>()
                        .ReplaceTokenStoreResolver<OpenIddictTokenStoreResolver>();

                    options.Services.TryAddScoped(typeof(OpenIddictApplicationStore<,>));
                    options.Services.TryAddScoped(typeof(OpenIddictAuthorizationStore<,>));
                    options.Services.TryAddScoped(typeof(OpenIddictScopeStore<,>));
                    options.Services.TryAddScoped(typeof(OpenIddictTokenStore<,>));
                })
                .AddServer(options =>
                {
                    options.UseMvc();
                    options.EnableTokenEndpoint("/connect/token");
                    options.AllowPasswordFlow();
                    options.AcceptAnonymousClients();
                })
                .AddValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseMvcWithDefaultRoute();

            app.UseWelcomePage();
        }
    }
}
