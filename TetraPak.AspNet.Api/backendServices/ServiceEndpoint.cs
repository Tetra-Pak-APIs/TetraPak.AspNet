using System;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TetraPak.AspNet.Auth;
using TetraPak.Configuration;
using TetraPak.Logging;
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

        /// <summary>
        ///   Gets the service declaring the endpoint (a <see cref="ServiceEndpoint"/> object).
        /// </summary>
        protected ServiceEndpoints Parent { get; private set; }
        
        public IServiceAuthConfig ParentConfig => Parent;

        /// <inheritdoc />
        public string StringValue { get; protected set; }

        /// <inheritdoc />
        public ConfigPath ConfigPath => $"{Parent.ConfigPath}{ConfigPath.Separator}{Name}";

        internal IBackendService Service { get; set; }

        public virtual HttpClientOptions ClientOptions => new() { AuthConfig = this };

        /// <summary>
        ///   Gets the current <see cref="HttpContext"/> instance.
        /// </summary>
        public HttpContext HttpContext => AmbientData.HttpContext;
        
        /// <summary>
        ///   Gets the name of the service endpoint URL (as specified in the configuration).
        /// </summary>
        [StateDump]
        public string Name { get; internal set; }

        /// <summary>
        ///   Gets an object to provide access to ambient data.
        /// </summary>
        public AmbientData AmbientData { get; private set; }

        /// <summary>
        ///   Gets a logging provider.
        /// </summary>
        public ILogger Logger => AmbientData.Logger;

        public IConfiguration Configuration { get; private set; }

        /// <inheritdoc />
        [StateDump]
        public GrantType GrantType
        {
            get => _grantType is null or GrantType.Inherited ? Parent.GrantType : _grantType.Value;
            set => _grantType = value;
        }
        
        [StateDump]
        public string ClientId
        {
            get => GetClientIdAsync(new AuthContext(GrantType, this)).Result;
            set => _clientId = value?.Trim();
        }

        [StateDump]
        public string ClientSecret
        {
            get => GetClientSecretAsync(new AuthContext(GrantType, this)).Result;
            set => _clientSecret = value?.Trim();
        }

        [StateDump]
        public MultiStringValue Scope
        {
            get => GetScopeAsync(new AuthContext(GrantType, this)).Result;
            set => _scope = value;
        }

        /// <inheritdoc />
        public Task<Outcome<string>> GetClientIdAsync(
            AuthContext authContext, 
            CancellationToken? cancellationToken = null)
        {
            if (Parent.IsDelegated || string.IsNullOrWhiteSpace(_clientId))
                return Parent.GetClientIdAsync(authContext, cancellationToken);

            return Task.FromResult(Outcome<string>.Success(_clientId));
        }

        /// <inheritdoc />
        public Task<Outcome<string>> GetClientSecretAsync(
            AuthContext authContext, 
            CancellationToken? cancellationToken = null)
        {
            if (Parent.IsDelegated || string.IsNullOrWhiteSpace(_clientSecret))
                return Parent.GetClientSecretAsync(authContext, cancellationToken);

            return Task.FromResult(Outcome<string>.Success(_clientSecret));
        }

        /// <inheritdoc />
        public Task<Outcome<MultiStringValue>> GetScopeAsync(
            AuthContext authContext,
            CancellationToken? cancellationToken = null)
        {
            if (Parent.IsDelegated || string.IsNullOrWhiteSpace(_scope))
                return Parent.GetScopeAsync(authContext, cancellationToken);

            return Task.FromResult(Outcome<MultiStringValue>.Success(_scope));
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
        public Task<Outcome<ActorToken>> GetAccessTokenAsync(bool forceStandardHeader = false) 
            => AmbientData.GetAccessTokenAsync(forceStandardHeader);

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
        
        public string GetConfiguredValue(string key) => Configuration[key];

        internal ServiceEndpoint WithConfig(IConfiguration config)
        {
            Configuration = config;
            var grantTypeSection = config.GetChildren()
                .FirstOrDefault(i => i.Key.Equals("grantType", StringComparison.InvariantCultureIgnoreCase));
            _grantType = parseGrantType(grantTypeSection?.Value, GrantType.Inherited);
            
            _clientId = config.GetChildren()
                .FirstOrDefault(i => i.Key.Equals("clientId", StringComparison.InvariantCultureIgnoreCase))?.Value;
            
            _clientSecret = config.GetChildren()
                .FirstOrDefault(i => i.Key.Equals("clientSecret", StringComparison.InvariantCultureIgnoreCase))?.Value;
            
            _scope = config.GetChildren()
                .FirstOrDefault(i => i.Key.Equals("scope", StringComparison.InvariantCultureIgnoreCase))?.Value;

            return this;
        }
        
        static GrantType parseGrantType(string stringValue, GrantType useDefault) 
        {
            if (string.IsNullOrWhiteSpace(stringValue))
                return useDefault;
        
            return !Enum.TryParse<GrantType>(stringValue, out var grantType)
                ? useDefault
                : grantType;
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

        /// <summary>
        ///   Initializes an <see cref="ServiceEndpoint"/> 
        /// </summary>
        /// <param name="ambientData"></param>
        protected ServiceEndpoint(AmbientData ambientData)
        {
            AmbientData = ambientData;
        }
    }
}