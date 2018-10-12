using System;
using System.Collections.Concurrent;
using System.Text;
using IDL.Giftcloud.Api.OpenIddict.Models;
using IDL.Giftcloud.Api.OpenIddict.Stores;
using Microsoft.Extensions.DependencyInjection;
using OpenIddict.Abstractions;

namespace IDL.Giftcloud.Api.OpenIddict.Resolvers
{
    public class OpenIddictApplicationStoreResolver : IOpenIddictApplicationStoreResolver
    {
        private static readonly ConcurrentDictionary<Type, Type> _cache = new ConcurrentDictionary<Type, Type>();

        private readonly IServiceProvider _provider;

        public OpenIddictApplicationStoreResolver(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IOpenIddictApplicationStore<TApplication> Get<TApplication>() where TApplication : class
        {
            var store = _provider.GetService<IOpenIddictApplicationStore<TApplication>>();
            if (store != null)
            {
                return store;
            }

            var type = _cache.GetOrAdd(typeof(TApplication), key =>
            {
                if (!typeof(OpenIddictApplication).IsAssignableFrom(typeof(TApplication)))
                {
                    throw new InvalidOperationException(new StringBuilder()
                        .AppendLine("The specified application type is not compatible with the Giftcloud stores.")
                        .Append("When enabling the Giftcloud stores, make sure you use the built-in ")
                        .Append("'OpenIddictApplication' entity (from the 'IDL.Giftcloud.Api.OpenIddict' project) ")
                        .Append("or a custom entity that inherits from the generic 'OpenIddictApplication' entity.")
                        .ToString());
                }

                return typeof(OpenIddictApplicationStore);
            });

            return (IOpenIddictApplicationStore<TApplication>)_provider.GetRequiredService(type);

        }
    }
}