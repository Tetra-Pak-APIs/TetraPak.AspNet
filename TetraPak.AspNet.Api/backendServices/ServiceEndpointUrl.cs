using System;
using System.Diagnostics;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;
using TetraPak.Serialization;

namespace TetraPak.AspNet.Api
{
    [JsonConverter(typeof(JsonStringValueSerializer<ServiceEndpointUrl>))]
    [DebuggerDisplay("{" + nameof(StringValue) + "}")]
    public class ServiceEndpointUrl : IStringValue
    {
        /// <inheritdoc />
        public string StringValue { get; protected set; }

        /// <summary>
        ///   Gets the name of the service endpoint URL (as specified in the configuration).
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        ///   Gets an object to provide access to ambient data.
        /// </summary>
        protected AmbientData AmbientData { get; }

        /// <summary>
        ///   Gets a logging provider.
        /// </summary>
        public ILogger Logger => AmbientData.Logger;

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
        public ServiceEndpointUrl(string stringValue)
        {
            StringValue = stringValue ?? throw new ArgumentNullException(nameof(stringValue));
        }

        protected ServiceEndpointUrl(AmbientData ambientData)
        {
            AmbientData = ambientData;
        }

        /// <summary>
        ///   Implicitly converts a string literal into a <see cref="ServiceEndpointUrl"/>.
        /// </summary>
        /// <param name="stringValue">
        ///   A string representation of the <see cref="ServiceEndpointUrl"/> value.
        /// </param>
        /// <returns>
        ///   A <see cref="ServiceEndpointUrl"/> value.
        /// </returns>
        /// <exception cref="FormatException">
        ///   The <paramref name="stringValue"/> string representation was incorrectly formed.
        /// </exception>
        public static implicit operator ServiceEndpointUrl(string stringValue) => new(stringValue);

        /// <summary>
        ///   Implicitly converts a <see cref="ServiceEndpointUrl"/> value into its <see cref="string"/> representation.
        /// </summary>
        /// <param name="value">
        ///   A <see cref="ServiceEndpointUrl"/> value to be implicitly converted into its <see cref="string"/> representation.
        /// </param>
        /// <returns>
        ///   The <see cref="string"/> representation of <paramref name="value"/>.
        /// </returns>
        public static implicit operator string(ServiceEndpointUrl value) => value?.StringValue;

        /// <inheritdoc />
        public override string ToString() => StringValue;

        #region .  Equality  .

        /// <summary>
        ///   Determines whether the specified value is equal to the current value.
        /// </summary>
        /// <param name="other">
        ///   A <see cref="ServiceEndpointUrl"/> value to compare to this value.
        /// </param>
        /// <returns>
        ///   <c>true</c> if <paramref name="other"/> is equal to the current value; otherwise <c>false</c>.
        /// </returns>
        public bool Equals(ServiceEndpointUrl other)
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
            return !(obj is null) && (obj is ServiceEndpointUrl other && Equals(other));
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
        public static bool operator ==(ServiceEndpointUrl left, ServiceEndpointUrl right)
        {
            return left?.Equals(right) ?? right is null;
        }

        /// <summary>
        ///   Comparison operator overload.
        /// </summary>
        public static bool operator !=(ServiceEndpointUrl left, ServiceEndpointUrl right)
        {
            return !left?.Equals(right) ?? !(right is null);
        }

        #endregion
    }
}