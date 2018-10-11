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
    public class OpenIddictApplicationStore : OpenIddictApplicationStore<OpenIddictApplication, Guid>
    {

    }

    /// <inheritdoc />
    public class OpenIddictApplicationStore<TKey> : OpenIddictApplicationStore<OpenIddictApplication<TKey>, TKey>
        where TKey : IEquatable<TKey>
    {
    }

    /// <inheritdoc />
    /// <typeparam name="TApplication">The type of the Application entity.</typeparam>
    /// <typeparam name="TKey">The type of the entity primary keys.</typeparam>
    public class OpenIddictApplicationStore<TApplication, TKey> : IOpenIddictApplicationStore<TApplication>
        where TApplication : OpenIddictApplication<TKey>
        where TKey : IEquatable<TKey>
    {
        public Task<long> CountAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<long> CountAsync<TResult>(Func<IQueryable<TApplication>, IQueryable<TResult>> query, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(TApplication application, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TApplication application, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<TApplication> FindByIdAsync(string identifier, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<TApplication> FindByClientIdAsync(string identifier, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ImmutableArray<TApplication>> FindByPostLogoutRedirectUriAsync(string address, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ImmutableArray<TApplication>> FindByRedirectUriAsync(string address, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<TResult> GetAsync<TState, TResult>(Func<IQueryable<TApplication>, TState, IQueryable<TResult>> query, TState state, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<string> GetClientIdAsync(TApplication application, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<string> GetClientSecretAsync(TApplication application, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<string> GetClientTypeAsync(TApplication application, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<string> GetConsentTypeAsync(TApplication application, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<string> GetDisplayNameAsync(TApplication application, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<string> GetIdAsync(TApplication application, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ImmutableArray<string>> GetPermissionsAsync(TApplication application, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ImmutableArray<string>> GetPostLogoutRedirectUrisAsync(TApplication application, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<JObject> GetPropertiesAsync(TApplication application, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ImmutableArray<string>> GetRedirectUrisAsync(TApplication application, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<TApplication> InstantiateAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ImmutableArray<TApplication>> ListAsync(int? count, int? offset, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ImmutableArray<TResult>> ListAsync<TState, TResult>(Func<IQueryable<TApplication>, TState, IQueryable<TResult>> query, TState state, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetClientIdAsync(TApplication application, string identifier, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetClientSecretAsync(TApplication application, string secret, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetClientTypeAsync(TApplication application, string type, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetConsentTypeAsync(TApplication application, string type, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetDisplayNameAsync(TApplication application, string name, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetPermissionsAsync(TApplication application, ImmutableArray<string> permissions, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetPostLogoutRedirectUrisAsync(TApplication application, ImmutableArray<string> addresses,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetPropertiesAsync(TApplication application, JObject properties, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetRedirectUrisAsync(TApplication application, ImmutableArray<string> addresses, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TApplication application, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}