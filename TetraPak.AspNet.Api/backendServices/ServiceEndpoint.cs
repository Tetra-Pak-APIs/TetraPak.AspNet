using System;
using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Auth;
using TetraPak.Serialization;

namespace TetraPak.AspNet.Api
{
    [JsonConverter(typeof(JsonStringValueSerializer<ServiceEndpoint>))]
    [DebuggerDisplay("{" + nameof(StringValue) + "}")]
    public class ServiceEndpoint : IStringValue, IServiceAuthConfig, IAccessTokenProvider
    {
        GrantType? _grantType;
        string _clientId;
        string _clientSecret;
        MultiStringValue _scope;
        
        protected ServiceEndpoints Parent { get; private set; }
        
        /// <inheritdoc />
        public string StringValue { get; protected set; }

        public string Path => $"{Parent.Path}:{Name}";

        internal IBackendService Service { get; set; }
        
        public virtual HttpClientOptions ClientOptions => new() { AuthConfig = this };
        
        /// <summary>
        ///   Gets the name of the service endpoint URL (as specified in the configuration).
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        ///   Gets an object to provide access to ambient data.
        /// </summary>
        protected AmbientData AmbientData { get; private set; }

        /// <summary>
        ///   Gets a logging provider.
        /// </summary>
        public ILogger Logger => AmbientData.Logger;

        /// <inheritdoc />
        public GrantType GrantType
        {
            get => _grantType is null or GrantType.Inherited ? Parent.GrantType : _grantType.Value;
            set => _grantType = value;
        }

        /// <inheritdoc />
        public string ClientId
        {
            get => _clientId ?? Parent.ClientId;
            set => _clientId = value;
        }

        /// <inheritdoc />
        public string ClientSecret
        {
            get => _clientSecret ?? Parent.ClientSecret;
            set => _clientSecret = value;
        }

        /// <inheritdoc />
        public MultiStringValue Scope
        {
            get => _scope ?? Parent.Scope;
            set => _scope = value;
        }

        /// <summary>
        ///   Implicitly converts a string literal into a <see cref="ServiceEndpoint"/>.
        /// </summary>
        /// <param name="stringValue">
        ///   A string representation of the <see cref="ServiceEndpoint"/> value.
        /// </param>
        /// <returns>
        ///   A <see cref="ServiceEndpoint"/> value.
        /// </returns>
        /// <exception cref="FormatException">
        ///   The <paramref name="stringValue"/> string representation was incorrectly formed.
        /// </exception>
        public static implicit operator ServiceEndpoint(string stringValue) => new(stringValue);

        /// <summary>
        ///   Implicitly converts a <see cref="ServiceEndpoint"/> value into its <see cref="string"/> representation.
        /// </summary>
        /// <param name="value">
        ///   A <see cref="ServiceEndpoint"/> value to be implicitly converted into its <see cref="string"/> representation.
        /// </param>
        /// <returns>
        ///   The <see cref="string"/> representation of <paramref name="value"/>.
        /// </returns>
        public static implicit operator string(ServiceEndpoint value) => value?.StringValue;

        /// <inheritdoc />
        public override string ToString() => StringValue;

        /// <inheritdoc />
        public Task<Outcome<ActorToken>> GetAccessTokenAsync() => AmbientData.GetAccessTokenAsync();

        #region .  Equality  .

        /// <summary>
        ///   Determines whether the specified value is equal to the current value.
        /// </summary>
        /// <param name="other">
        ///   A <see cref="ServiceEndpoint"/> value to compare to this value.
        /// </param>
        /// <returns>
        ///   <c>true</c> if <paramref name="other"/> is equal to the current value; otherwise <c>false</c>.
        /// </returns>
        public bool Equals(ServiceEndpoint other)
        {
            return !(other is null) && string.Equals(StringValue, other.StringValue);
        }

        /// <summary>
        ///   Determines whether the specified object is equal to the current version.
        /// </summary>
        /// <param name="obj">
        ///   An object to compare to this value.
        /// </param>
        /// <returns>
        ///   <c>true</c> if the specified object is equal to the current version; otherwise <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return !(obj is null) && (obj is ServiceEndpoint other && Equals(other));
        }

        /// <summary>
        ///   Serves as the default hash function.
        /// </summary>
        /// <returns>
        ///   A hash code for the current value.
        /// </returns>
        public override int GetHashCode()
        {
            return (StringValue != null ? StringValue.GetHashCode() : 0);
        }

        /// <summary>
        ///   Comparison operator overload.
        /// </summary>
        public static bool operator ==(ServiceEndpoint left, ServiceEndpoint right)
        {
            return left?.Equals(right) ?? right is null;
        }

        /// <summary>
        ///   Comparison operator overload.
        /// </summary>
        public static bool operator !=(ServiceEndpoint left, ServiceEndpoint right)
        {
            return !left?.Equals(right) ?? right is { };
        }

        #endregion

        internal ServiceEndpoint WithIdentity(string name, ServiceEndpoints parent)
        {
            Name = name;
            Parent = parent ?? throw new ArgumentNullException(nameof(parent));
            AmbientData = parent.AmbientData;
            return this;
        }

        internal ServiceEndpoint WithConfig(
            GrantType grantType, 
            string clientId, 
            string clientSecret,
            MultiStringValue scope)
        {
            _grantType = grantType;
            _clientId = clientId;
            _clientSecret = clientSecret;
            _scope = scope;
            return this;
        }
        
        /// <summary>
        ///   Initializes the value.
        /// </summary>
        /// <param name="stringValue">
        ///   The new value's string representation (will automatically be parsed).
        /// </param>
        /// <exception cref="FormatException">
        ///   The <paramref name="stringValue"/> string representation was incorrectly formed.
        /// </exception>
        [DebuggerStepThrough]
        public ServiceEndpoint(string stringValue)
        {
            StringValue = stringValue ?? throw new ArgumentNullException(nameof(stringValue));
        }

        protected ServiceEndpoint(AmbientData ambientData)
        {
            AmbientData = ambientData;
        }
    }
}