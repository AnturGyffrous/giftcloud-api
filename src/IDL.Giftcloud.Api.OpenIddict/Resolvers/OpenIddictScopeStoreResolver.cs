using System;
using System.Collections.Concurrent;
using System.Text;
using IDL.Giftcloud.Api.OpenIddict.Models;
using IDL.Giftcloud.Api.OpenIddict.Stores;
using Microsoft.Extensions.DependencyInjection;
using OpenIddict.Abstractions;

namespace IDL.Giftcloud.Api.OpenIddict.Resolvers
{
    public class OpenIddictScopeStoreResolver : IOpenIddictScopeStoreResolver
    {
        private static readonly ConcurrentDictionary<Type, Type> _cache = new ConcurrentDictionary<Type, Type>();

        private readonly IServiceProvider _provider;

        public OpenIddictScopeStoreResolver(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IOpenIddictScopeStore<TScope> Get<TScope>() where TScope : class
        {
            var store = _provider.GetService<IOpenIddictScopeStore<TScope>>();
            if (store != null)
            {
                return store;
            }

            var type = _cache.GetOrAdd(typeof(TScope), key =>
            {
                var root = key.FindGenericBaseType(typeof(OpenIddictScope<>));
                if (root == null)
                {
                    throw new InvalidOperationException(new StringBuilder()
                        .AppendLine("The specified scope type is not compatible with the Giftcloud stores.")
                        .Append("When enabling the Giftcloud stores, make sure you use the built-in ")
                        .Append("'OpenIddictScope' entity (from the 'IDL.Giftcloud.Api.OpenIddict' project) ")
                        .Append("or a custom entity that inherits from the generic 'OpenIddictScope' entity.")
                        .ToString());
                }


                return typeof(OpenIddictScopeStore<,>).MakeGenericType(
                    /* TScope: */ key,
                    /* TKey: */ root.GenericTypeArguments[0]);
            });

            return (IOpenIddictScopeStore<TScope>)_provider.GetRequiredService(type);
        }
    }
}