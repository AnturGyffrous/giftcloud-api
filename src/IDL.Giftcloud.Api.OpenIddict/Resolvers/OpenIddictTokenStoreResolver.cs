using System;
using System.Collections.Concurrent;
using System.Text;
using IDL.Giftcloud.Api.OpenIddict.Models;
using IDL.Giftcloud.Api.OpenIddict.Stores;
using Microsoft.Extensions.DependencyInjection;
using OpenIddict.Abstractions;

namespace IDL.Giftcloud.Api.OpenIddict.Resolvers
{
    public class OpenIddictTokenStoreResolver : IOpenIddictTokenStoreResolver
    {
        private static readonly ConcurrentDictionary<Type, Type> _cache = new ConcurrentDictionary<Type, Type>();

        private readonly IServiceProvider _provider;

        public OpenIddictTokenStoreResolver(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IOpenIddictTokenStore<TToken> Get<TToken>() where TToken : class
        {
            var store = _provider.GetService<IOpenIddictTokenStore<TToken>>();
            if (store != null)
            {
                return store;
            }

            var type = _cache.GetOrAdd(typeof(TToken), key =>
            {
                var root = key.FindGenericBaseType(typeof(OpenIddictToken<,,>));
                if (root == null)
                {
                    throw new InvalidOperationException(new StringBuilder()
                        .AppendLine("The specified token type is not compatible with the Giftcloud stores.")
                        .Append("When enabling the Giftcloud stores, make sure you use the built-in ")
                        .Append("'OpenIddictToken' entity (from the 'IDL.Giftcloud.Api.OpenIddict' project) ")
                        .Append("or a custom entity that inherits from the generic 'OpenIddictToken' entity.")
                        .ToString());
                }

                return typeof(OpenIddictTokenStore<,>).MakeGenericType(
                    /* TToken: */ key,
                    /* TKey: */ root.GenericTypeArguments[0]);
            });

            return (IOpenIddictTokenStore<TToken>)_provider.GetRequiredService(type);
        }
    }
}