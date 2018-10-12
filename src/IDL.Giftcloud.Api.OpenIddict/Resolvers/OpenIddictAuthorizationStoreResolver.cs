using System;
using System.Collections.Concurrent;
using System.Text;
using IDL.Giftcloud.Api.OpenIddict.Models;
using IDL.Giftcloud.Api.OpenIddict.Stores;
using Microsoft.Extensions.DependencyInjection;
using OpenIddict.Abstractions;

namespace IDL.Giftcloud.Api.OpenIddict.Resolvers
{
    public class OpenIddictAuthorizationStoreResolver : IOpenIddictAuthorizationStoreResolver
    {
        private static readonly ConcurrentDictionary<Type, Type> _cache = new ConcurrentDictionary<Type, Type>();

        private readonly IServiceProvider _provider;

        public OpenIddictAuthorizationStoreResolver(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IOpenIddictAuthorizationStore<TAuthorization> Get<TAuthorization>() where TAuthorization : class
        {
            var store = _provider.GetService<IOpenIddictAuthorizationStore<TAuthorization>>();
            if (store != null)
            {
                return store;
            }

            var type = _cache.GetOrAdd(typeof(TAuthorization), key =>
            {
                if (!typeof(OpenIddictAuthorization).IsAssignableFrom(typeof(TAuthorization)))
                {
                    throw new InvalidOperationException(new StringBuilder()
                        .AppendLine("The specified authorization type is not compatible with the Giftcloud stores.")
                        .Append("When enabling the Giftcloud stores, make sure you use the built-in ")
                        .Append("'OpenIddictAuthorization' entity (from the 'IDL.Giftcloud.Api.OpenIddict' project) ")
                        .Append("or a custom entity that inherits from the generic 'OpenIddictAuthorization' entity.")
                        .ToString());
                }

                return typeof(OpenIddictAuthorizationStore);
            });

            return (IOpenIddictAuthorizationStore<TAuthorization>)_provider.GetRequiredService(type);
        }
    }
}