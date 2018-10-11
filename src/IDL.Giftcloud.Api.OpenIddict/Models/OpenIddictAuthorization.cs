using System;

namespace IDL.Giftcloud.Api.OpenIddict.Models
{
    /// <inheritdoc />
    public class OpenIddictAuthorization : OpenIddictAuthorization<Guid>
    {
    }

    /// <inheritdoc />
    public class OpenIddictAuthorization<TKey> : OpenIddictAuthorization<TKey, OpenIddictApplication<TKey>>
        where TKey : IEquatable<TKey>
    {

    }
    /// <summary>
    /// Represents an OpenIddict authorization.
    /// </summary>
    /// <typeparam name="TKey">The type of the entity primary key.</typeparam>
    /// <typeparam name="TApplication">The type of the Application entity.</typeparam>
    public class OpenIddictAuthorization<TKey, TApplication> where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Gets or sets the application associated with the current authorization.
        /// </summary>
        public virtual TApplication Application { get; set; }

        /// <summary>
        /// Gets or sets the concurrency token.
        /// </summary>
        public virtual string ConcurrencyToken { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Gets or sets the unique identifier
        /// associated with the current authorization.
        /// </summary>
        public virtual TKey Id { get; set; }

        /// <summary>
        /// Gets or sets the additional properties associated with the current authorization.
        /// </summary>
        public virtual string Properties { get; set; }

        /// <summary>
        /// Gets or sets the scopes associated with the current authorization.
        /// </summary>
        public virtual string[] Scopes { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Gets or sets the status of the current authorization.
        /// </summary>
        public virtual string Status { get; set; }

        /// <summary>
        /// Gets or sets the subject associated with the current authorization.
        /// </summary>
        public virtual string Subject { get; set; }

        /// <summary>
        /// Gets or sets the type of the current authorization.
        /// </summary>
        public virtual string Type { get; set; }
    }
}