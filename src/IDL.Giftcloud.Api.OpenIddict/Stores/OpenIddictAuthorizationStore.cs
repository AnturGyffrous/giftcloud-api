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
    public class OpenIddictAuthorizationStore : OpenIddictAuthorizationStore<OpenIddictAuthorization, Guid>
    {
    }

    /// <inheritdoc />
    public class OpenIddictAuthorizationStore<TKey> : OpenIddictAuthorizationStore<OpenIddictAuthorization<TKey>, TKey>
        where TKey : IEquatable<TKey>
    {
    }

    /// <inheritdoc />
    /// <typeparam name="TAuthorization">The type of the Entity Framework database context.</typeparam>
    /// <typeparam name="TKey">The type of the entity primary keys.</typeparam>
    public class OpenIddictAuthorizationStore<TAuthorization, TKey> : IOpenIddictAuthorizationStore<TAuthorization>
        where TAuthorization : OpenIddictAuthorization<TKey>
        where TKey : IEquatable<TKey>
    {
        public Task<long> CountAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<long> CountAsync<TResult>(Func<IQueryable<TAuthorization>, IQueryable<TResult>> query, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(TAuthorization authorization, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TAuthorization authorization, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ImmutableArray<TAuthorization>> FindAsync(string subject, string client, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ImmutableArray<TAuthorization>> FindAsync(string subject, string client, string status, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ImmutableArray<TAuthorization>> FindAsync(string subject, string client, string status, string type, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<TAuthorization> FindByIdAsync(string identifier, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ImmutableArray<TAuthorization>> FindBySubjectAsync(string subject, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<string> GetApplicationIdAsync(TAuthorization authorization, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<TResult> GetAsync<TState, TResult>(Func<IQueryable<TAuthorization>, TState, IQueryable<TResult>> query, TState state, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<string> GetIdAsync(TAuthorization authorization, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<JObject> GetPropertiesAsync(TAuthorization authorization, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ImmutableArray<string>> GetScopesAsync(TAuthorization authorization, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<string> GetStatusAsync(TAuthorization authorization, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<string> GetSubjectAsync(TAuthorization authorization, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<string> GetTypeAsync(TAuthorization authorization, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<TAuthorization> InstantiateAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ImmutableArray<TAuthorization>> ListAsync(int? count, int? offset, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ImmutableArray<TResult>> ListAsync<TState, TResult>(Func<IQueryable<TAuthorization>, TState, IQueryable<TResult>> query, TState state, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task PruneAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetApplicationIdAsync(TAuthorization authorization, string identifier, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetPropertiesAsync(TAuthorization authorization, JObject properties, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetScopesAsync(TAuthorization authorization, ImmutableArray<string> scopes, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetStatusAsync(TAuthorization authorization, string status, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetSubjectAsync(TAuthorization authorization, string subject, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetTypeAsync(TAuthorization authorization, string type, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TAuthorization authorization, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}