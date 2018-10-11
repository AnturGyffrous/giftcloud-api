using System;

namespace IDL.Giftcloud.Api.OpenIddict.Models
{
    /// <inheritdoc />
    public class OpenIddictApplication : OpenIddictApplication<Guid>
    {
    }

    /// <summary>
    /// Represents an OpenIddict application.
    /// </summary>
    /// <typeparam name="TKey">The type of the entity primary key.</typeparam>
    public class OpenIddictApplication<TKey> where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Gets or sets the client identifier
        /// associated with the current application.
        /// </summary>
        public virtual string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the client secret associated with the current application.
        /// Note: depending on the application manager used to create this instance,
        /// this property may be hashed or encrypted for security reasons.
        /// </summary>
        public virtual string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the concurrency token.
        /// </summary>
        public virtual string ConcurrencyToken { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Gets or sets the consent type
        /// associated with the current application.
        /// </summary>
        public virtual string ConsentType { get; set; }

        /// <summary>
        /// Gets or sets the display name
        /// associated with the current application.
        /// </summary>
        public virtual string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier
        /// associated with the current application.
        /// </summary>
        public virtual TKey Id { get; set; }

        /// <summary>
        /// Gets or sets the permissions associated with the current application.
        /// </summary>
        public virtual string[] Permissions { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Gets or sets the logout callback URLs associated with the current application.
        /// </summary>
        public virtual string[] PostLogoutRedirectUris { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Gets or sets the additional properties associated with the current application.
        /// </summary>
        public virtual string Properties { get; set; }

        /// <summary>
        /// Gets or sets the callback URLs associated with the current application.
        /// </summary>
        public virtual string[] RedirectUris { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Gets or sets the application type
        /// associated with the current application.
        /// </summary>
        public virtual string Type { get; set; }
    }
}