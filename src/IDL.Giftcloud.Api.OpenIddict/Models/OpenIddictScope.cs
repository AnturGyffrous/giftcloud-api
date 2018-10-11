using System;

namespace IDL.Giftcloud.Api.OpenIddict.Models
{
    /// <inheritdoc />
    public class OpenIddictScope : OpenIddictScope<Guid>
    {
    }

    /// <summary>
    /// Represents an OpenIddict scope.
    /// </summary>
    /// <typeparam name="TKey">The type of the entity primary key.</typeparam>
    public class OpenIddictScope<TKey> where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Gets or sets the concurrency token.
        /// </summary>
        public virtual string ConcurrencyToken { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Gets or sets the public description
        /// associated with the current scope.
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Gets or sets the display name
        /// associated with the current scope.
        /// </summary>
        public virtual string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier
        /// associated with the current scope.
        /// </summary>
        public virtual TKey Id { get; set; }

        /// <summary>
        /// Gets or sets the unique name
        /// associated with the current scope.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the additional properties associated with the current scope.
        /// </summary>
        public virtual string Properties { get; set; }

        /// <summary>
        /// Gets or sets the resources associated with the current scope.
        /// </summary>
        public virtual string[] Resources { get; set; } = Array.Empty<string>();
    }
}