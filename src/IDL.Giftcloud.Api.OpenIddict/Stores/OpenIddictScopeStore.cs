using System;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IDL.Giftcloud.Api.OpenIddict.Models;
using Newtonsoft.Json.Linq;
using OpenIddict.Abstractions;

namespace IDL.Giftcloud.Api.OpenIddict.Stores
{
    /// <inheritdoc />
    public class OpenIddictScopeStore : OpenIddictScopeStore<OpenIddictScope<Guid>, Guid>
    {
    }

    /// <inheritdoc />
    public class OpenIddictScopeStore<TKey> : OpenIddictScopeStore<OpenIddictScope<TKey>, TKey>
        where TKey : IEquatable<TKey>
    {
    }

    /// <inheritdoc />
    /// <typeparam name="TScope">The type of the Scope entity.</typeparam>
    /// <typeparam name="TKey">The type of the entity primary keys.</typeparam>
    public class OpenIddictScopeStore<TScope, TKey> : IOpenIddictScopeStore<TScope>
        where TScope : OpenIddictScope<TKey>
        where TKey : IEquatable<TKey>
    {
        public Task<long> CountAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<long> CountAsync<TResult>(Func<IQueryable<TScope>, IQueryable<TResult>> query, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(TScope scope, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TScope scope, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<TScope> FindByIdAsync(string identifier, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<TScope> FindByNameAsync(string name, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ImmutableArray<TScope>> FindByNamesAsync(ImmutableArray<string> names, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ImmutableArray<TScope>> FindByResourceAsync(string resource, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<TResult> GetAsync<TState, TResult>(Func<IQueryable<TScope>, TState, IQueryable<TResult>> query, TState state, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<string> GetDescriptionAsync(TScope scope, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<string> GetDisplayNameAsync(TScope scope, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<string> GetIdAsync(TScope scope, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<string> GetNameAsync(TScope scope, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<JObject> GetPropertiesAsync(TScope scope, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ImmutableArray<string>> GetResourcesAsync(TScope scope, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<TScope> InstantiateAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ImmutableArray<TScope>> ListAsync(int? count, int? offset, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ImmutableArray<TResult>> ListAsync<TState, TResult>(Func<IQueryable<TScope>, TState, IQueryable<TResult>> query, TState state, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetDescriptionAsync(TScope scope, string description, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetDisplayNameAsync(TScope scope, string name, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNameAsync(TScope scope, string name, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetPropertiesAsync(TScope scope, JObject properties, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetResourcesAsync(TScope scope, ImmutableArray<string> resources, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TScope scope, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}