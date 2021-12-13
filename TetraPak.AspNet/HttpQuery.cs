using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Represents HTTP query parameters.
    /// </summary>
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class HttpQuery : IDictionary<string, string?>, IStringValue
    {
        /// <summary>
        ///   The HTTP query parameter collection qualifier symbol.
        /// </summary>
        public const char Qualifier = '?'; 
        
        /// <summary>
        ///   The HTTP query parameter collection value (pair) separator symbol.
        /// </summary>
        public const char Separator = '&';
        
        /// <summary>
        ///   The HTTP query parameter collection value (pair) assignment symbol.
        /// </summary>
        const char Assign = '=';
        
        readonly IDictionary<string, string?> _dictionary;
        string? _stringValue;

        /// <summary>
        ///   Gets the query parameter's textual representation. 
        /// </summary>
        public string StringValue => getStringValue();

        /// <inheritdoc />
        public override string ToString() => getStringValue();

        /// <summary>
        ///   Returns a string that represents the current object, while specifying whether to include
        ///   the query qualifier character (<see cref="Qualifier"/>).
        /// </summary>
        /// <param name="includeQualifier">
        ///   Specifies whether to prepend the result with the <see cref="Qualifier"/> symbol.
        /// </param>
        /// <returns>
        ///   A <see cref="string"/> that represents the current object.
        /// </returns>
        public string ToString(bool includeQualifier) => getStringValue(includeQualifier);
        
        string getStringValue(bool includeQualifier = false)
        {
            lock (_dictionary)
            {
                if (_stringValue is { })
                    return _stringValue;

                var sb = new StringBuilder();
                if (includeQualifier)
                {
                    sb.Append(Qualifier);
                }
                var isFirst = true;
                foreach (var (key, value) in _dictionary)
                {
                    if (!isFirst)
                    {
                        sb.Append(Separator);
                    }

                    sb.Append(key);
                    isFirst = false;
                    if (value is null)
                        continue;

                    sb.Append(Assign);
                    sb.Append(value);
                }

                return sb.ToString();
            }
        }

        void invalidateStringValue() => _stringValue = null;
        
        #region .  IDictionary  .

        /// <inheritdoc />
        public IEnumerator<KeyValuePair<string, string?>> GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_dictionary).GetEnumerator();
        }

        /// <inheritdoc />
        public void Add(KeyValuePair<string, string?> item)
        {
            _dictionary.Add(item);
            invalidateStringValue();
        }

        /// <inheritdoc />
        public void Clear()
        {
            _dictionary.Clear();
            invalidateStringValue();
        }

        /// <inheritdoc />
        public bool Contains(KeyValuePair<string, string?> item)
        {
            return _dictionary.Contains(item);
        }

        /// <inheritdoc />
        public void CopyTo(KeyValuePair<string, string?>[] array, int arrayIndex)
        {
            _dictionary.CopyTo(array, arrayIndex);
        }

        /// <inheritdoc />
        public bool Remove(KeyValuePair<string, string?> item)
        {
            if (!_dictionary.Remove(item))
                return false;
            
            invalidateStringValue();
            return true;
        }

        /// <inheritdoc />
        public int Count => _dictionary.Count;

        /// <inheritdoc />
        public bool IsReadOnly => _dictionary.IsReadOnly;

        /// <inheritdoc />
        public void Add(string key, string? value)
        {
            _dictionary.Add(key, value);
            invalidateStringValue();
        }

        /// <inheritdoc />
        public bool ContainsKey(string key)
        {
            return _dictionary.ContainsKey(key);
        }

        /// <inheritdoc />
        public bool Remove(string key)
        {
            if (!_dictionary.Remove(key))
                return false;

            invalidateStringValue();
            return true;
        }

        /// <inheritdoc />
        public bool TryGetValue(string key, [MaybeNullWhen(false)] out string value)
        {
            return _dictionary.TryGetValue(key, out value);
        }

        /// <inheritdoc />
        public string? this[string key]
        {
            get => _dictionary[key];
            set
            {
                _dictionary[key] = value;
                invalidateStringValue();
            }
        }

        /// <inheritdoc />
        public ICollection<string> Keys => _dictionary.Keys;

        /// <inheritdoc />
        public ICollection<string?> Values => _dictionary.Values;

        #endregion

        /// <summary>
        ///   Implicitly converts a string representation of HTTP query parameters into
        ///   a <see cref="HttpQuery"/> object. 
        /// </summary>
        public static implicit operator HttpQuery(string s) => new(s);

        /// <summary>
        ///   Implicitly converts a <see cref="HttpQuery"/> object
        ///   into its <see cref="string"/> representation.
        /// </summary>
        public static implicit operator string?(HttpQuery? queryParameters) => queryParameters?.StringValue; 

        IEnumerable<KeyValuePair<string, string?>> parse(string? stringValue)
        {
            return OnParse(stringValue);
        }
        
        /// <summary>
        ///   Invoked to parse a <see cref="string"/> into a 
        /// </summary>
        /// <param name="stringValue">
        ///   The <see cref="string"/> to be parsed.
        /// </param>
        /// <returns>
        ///   A collection of <see cref="KeyValuePair{TKey,TValue}"/>, representing the key/value pairs
        ///   found in the <paramref name="stringValue"/>.
        /// </returns>
        protected virtual IEnumerable<KeyValuePair<string,string?>> OnParse(string? stringValue)
        {
            var s = stringValue?.Trim().TrimStart(Qualifier);
            if (string.IsNullOrEmpty(s))
                return Array.Empty<KeyValuePair<string, string?>>();
            
            var pairs = s.Split(Separator);
            var keyValuePairs = new List<KeyValuePair<string, string?>>();
            foreach (var pair in pairs)
            {
                if (string.IsNullOrEmpty(pair))
                    continue;
                
                var kv = pair.Split(Assign, StringSplitOptions.RemoveEmptyEntries);
                if (kv.Length == 1)
                    keyValuePairs.Add(new KeyValuePair<string, string?>(kv[0].Trim(), null!));
                
                keyValuePairs.Add(new KeyValuePair<string, string?>(kv[0].Trim(), kv[1].Trim()));
            }

            return keyValuePairs;
        }

        /// <summary>
        ///   Initializes (empty) query parameters. 
        /// </summary>
        public HttpQuery()
        {
            _dictionary = new Dictionary<string, string?>();
        }

        /// <summary>
        ///   Initializes the <see cref="HttpQuery"/> from a textual representation.
        /// </summary>
        public HttpQuery(string? queryParameters)
        {
            _dictionary = new Dictionary<string, string?>(parse(queryParameters));
        }
    }

    /// <summary>
    ///   Provides convenient methods for dealing with <see cref="HttpQuery"/>.
    /// </summary>
    public static class HttpQueryParametersHelper
    {
        /// <summary>
        ///   Safely examines a (nullable) <see cref="HttpQuery"/> object and returns
        ///   a value to indicate is is empty (or unassigned/<c>null</c>). 
        /// </summary>
        public static bool IsEmpty(this HttpQuery? queryParameters) 
            => queryParameters is null || queryParameters.Count == 0;
    }
}