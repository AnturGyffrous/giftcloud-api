﻿using System;
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
    public class OpenIddictTokenStore : OpenIddictTokenStore<OpenIddictToken<Guid>, Guid>
    {
    }

    /// <inheritdoc />
    public class OpenIddictTokenStore<TKey> : OpenIddictTokenStore<OpenIddictToken<TKey>, TKey>
        where TKey : IEquatable<TKey>
    {
    }

    /// <inheritdoc />
    /// <typeparam name="TToken">The type of the Token entity.</typeparam>
    /// <typeparam name="TKey">The type of the entity primary keys.</typeparam>
    public class OpenIddictTokenStore<TToken, TKey> : IOpenIddictTokenStore<TToken>
        where TToken : OpenIddictToken<TKey>
        where TKey : IEquatable<TKey>
    {
        public Task<long> CountAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<long> CountAsync<TResult>(Func<IQueryable<TToken>, IQueryable<TResult>> query, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(TToken token, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TToken token, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ImmutableArray<TToken>> FindByApplicationIdAsync(string identifier, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ImmutableArray<TToken>> FindByAuthorizationIdAsync(string identifier, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<TToken> FindByIdAsync(string identifier, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<TToken> FindByReferenceIdAsync(string identifier, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ImmutableArray<TToken>> FindBySubjectAsync(string subject, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<string> GetApplicationIdAsync(TToken token, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<TResult> GetAsync<TState, TResult>(Func<IQueryable<TToken>, TState, IQueryable<TResult>> query, TState state, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<string> GetAuthorizationIdAsync(TToken token, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<DateTimeOffset?> GetCreationDateAsync(TToken token, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<DateTimeOffset?> GetExpirationDateAsync(TToken token, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<string> GetIdAsync(TToken token, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<string> GetPayloadAsync(TToken token, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<JObject> GetPropertiesAsync(TToken token, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<string> GetReferenceIdAsync(TToken token, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<string> GetStatusAsync(TToken token, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<string> GetSubjectAsync(TToken token, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<string> GetTokenTypeAsync(TToken token, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<TToken> InstantiateAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ImmutableArray<TToken>> ListAsync(int? count, int? offset, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ImmutableArray<TResult>> ListAsync<TState, TResult>(Func<IQueryable<TToken>, TState, IQueryable<TResult>> query, TState state, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task PruneAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetApplicationIdAsync(TToken token, string identifier, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetAuthorizationIdAsync(TToken token, string identifier, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetCreationDateAsync(TToken token, DateTimeOffset? date, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetExpirationDateAsync(TToken token, DateTimeOffset? date, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetPayloadAsync(TToken token, string payload, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetPropertiesAsync(TToken token, JObject properties, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetReferenceIdAsync(TToken token, string identifier, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetStatusAsync(TToken token, string status, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetSubjectAsync(TToken token, string subject, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetTokenTypeAsync(TToken token, string type, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TToken token, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}