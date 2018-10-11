using System;

namespace IDL.Giftcloud.Api.OpenIddict.Models
{
    /// <inheritdoc />
    public class OpenIddictToken : OpenIddictToken<Guid, OpenIddictApplication, OpenIddictAuthorization>
    {
    }

    /// <inheritdoc />
    public class OpenIddictToken<TKey> : OpenIddictToken<TKey, OpenIddictApplication<TKey>, OpenIddictAuthorization<TKey>>
        where TKey : IEquatable<TKey>
    {
    }

    /// <summary>
    /// Represents an OpenIddict token.
    /// </summary>
    /// <typeparam name="TKey">The type of the entity primary key.</typeparam>
    /// <typeparam name="TApplication">The type of the Application entity.</typeparam>
    /// <typeparam name="TAuthorization">The type of the Authorization entity.</typeparam>
    public class OpenIddictToken<TKey, TApplication, TAuthorization> where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Gets or sets the application associated with the current token.
        /// </summary>
        public virtual TApplication Application { get; set; }

        /// <summary>
        /// Gets or sets the authorization associated with the current token.
        /// </summary>
        public virtual TAuthorization Authorization { get; set; }

        /// <summary>
        /// Gets or sets the concurrency token.
        /// </summary>
        public virtual string ConcurrencyToken { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Gets or sets the date on which the token
        /// will start to be considered valid.
        /// </summary>
        public virtual DateTime? CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the date on which the token
        /// will no longer be considered valid.
        /// </summary>
        public virtual DateTime? ExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier
        /// associated with the current token.
        /// </summary>
        public virtual TKey Id { get; set; }

        /// <summary>
        /// Gets or sets the payload of the current token, if applicable.
        /// Note: this property is only used for reference tokens
        /// and may be encrypted for security reasons.
        /// </summary>
        public virtual string Payload { get; set; }

        /// <summary>
        /// Gets or sets the additional properties associated with the current token.
        /// </summary>
        public virtual string Properties { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier associated
        /// with the current token, if applicable.
        /// Note: this property is only used for reference tokens
        /// and may be hashed or encrypted for security reasons.
        /// </summary>
        public virtual string ReferenceId { get; set; }

        /// <summary>
        /// Gets or sets the status of the current token.
        /// </summary>
        public virtual string Status { get; set; }

        /// <summary>
        /// Gets or sets the subject associated with the current token.
        /// </summary>
        public virtual string Subject { get; set; }

        /// <summary>
        /// Gets or sets the type of the current token.
        /// </summary>
        public virtual string Type { get; set; }
    }
}