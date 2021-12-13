using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Represents the outcome of a HTTP request.
    /// </summary>
    /// <typeparam name="T">
    ///   The <see cref="Type"/> of data requested.
    /// </typeparam>
    public class HttpOutcome<T> : Outcome<T>
    {
        /// <summary>
        ///   Gets the HTTP request method used.
        /// </summary>
        public HttpMethod Method { get; }

        /// <summary>
        ///   Creates and returns a successful outcome with a requested value.
        /// </summary>
        /// <param name="method">
        ///   The HTTP request method used.
        /// </param>
        /// <param name="value">
        ///   The value to be carried by the outcome.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success and also carry
        ///   a value of type <typeparamref name="T"/>.
        /// </returns>
        public static HttpOutcome<T> Success(HttpMethod method, T value) => new(true, method, value);

        /// <summary>
        ///   Creates and returns a failed outcome.
        /// </summary>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate failure and also carry a default
        ///   value of type <typeparamref name="T"/>.
        /// </returns>
        public static HttpOutcome<T> Fail(HttpMethod method) => new(false, method, default!);

        /// <summary>
        ///   Creates and returns a failed outcome that also carries a specified value of type
        ///   <typeparamref name="T"/>.
        /// </summary>
        /// <param name="method">
        ///   The HTTP request method used.
        /// </param>
        /// <param name="value">
        ///   Assigns <see cref="Outcome{T}.Value"/>.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate failure.
        /// </returns>
        public static HttpOutcome<T> Fail(HttpMethod method, T value) 
            => new(false, method, value);

        /// <summary>
        ///   Creates and returns a failed outcome that carries an <see cref="Exception"/>.
        /// </summary>
        /// <param name="method">
        ///   The HTTP request method used.
        /// </param>
        /// <param name="exception">
        ///   Assigns the <see cref="Outcome.Exception"/>.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate failure.
        /// </returns>
        public static HttpOutcome<T> Fail(HttpMethod method, Exception exception) 
            => new(false, method, default!, exception);

        /// <summary>
        ///   Creates and returns a failed outcome that carries an <see cref="Exception"/> as well as a value.
        /// </summary>
        /// <param name="method">
        ///   The HTTP request method used.
        /// </param>
        /// <param name="exception">
        ///   Assigns <see cref="Outcome.Exception"/>.
        /// </param>
        /// <param name="value">
        ///   Assigns <see cref="Outcome{T}.Value"/>.
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate failure.
        /// </returns>
        public static HttpOutcome<T> Fail(HttpMethod method, Exception exception, T value) 
            => new(false, method, value, exception);

        /// <summary>
        ///   Initializes the <see cref="HttpOutcome{T}"/> object.
        /// </summary>
        /// <param name="result">
        ///   Initializes the outcome result (success/failure).
        /// </param>
        /// <param name="method">
        ///   Initializes the <see cref="Method"/>.
        /// </param>
        /// <param name="value">
        ///   Initializes the <see cref="Outcome{T}.Value"/>.
        /// </param>
        /// <param name="exception">
        ///   Initializes the <see cref="Outcome.Exception"/>.
        /// </param>
        protected HttpOutcome(bool result, HttpMethod method, T value, Exception? exception = null) 
        : base(result, value, exception)
        {
            Method = method;
        }
    }

    /// <summary>
    ///   Represents the outcome of a HTTP request.
    /// </summary>
    /// <typeparam name="T">
    ///   The <see cref="Type"/> of data requested.
    /// </typeparam>
    public class HttpEnumOutcome<T> : EnumOutcome<T>
    {
        /// <summary>
        ///   Gets the HTTP request method used.
        /// </summary>
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public HttpMethod Method { get; }

        /// <summary>
        ///   Creates and returns a successful outcome with a requested value.
        /// </summary>
        /// <param name="method">
        ///   The HTTP request method used.
        /// </param>
        /// <param name="value">
        ///   The value to be carried by the outcome.
        /// </param>
        /// <param name="totalCount">
        ///   The total amount of items available from source.
        /// </param>
        /// <returns>
        ///   An <see cref="HttpEnumOutcome{T}"/> to indicate success and also carry
        ///   a value of type <typeparamref name="T"/>.
        /// </returns>
        public static HttpEnumOutcome<T> Success(HttpMethod method, IReadOnlyCollection<T> value, int totalCount = 0) 
            => new(true, method, value, totalCount == 0 ? value.Count : totalCount);
        
        /// <summary>
        ///   Creates and returns a successful outcome with a requested value.
        /// </summary>
        /// <param name="method">
        ///   The HTTP request method used.
        /// </param>
        /// <param name="singleValue">
        ///   The value to be carried by the outcome.
        /// </param>
        /// <param name="totalCount">
        ///   The total amount of items available from source.
        /// </param>
        /// <returns>
        ///   An <see cref="HttpEnumOutcome{T}"/> to indicate success and also carry
        ///   a value of type <typeparamref name="T"/>.
        /// </returns>
        public static HttpEnumOutcome<T> Success(HttpMethod method, T singleValue, int totalCount = 0) 
            => new HttpEnumOutcome<T>(true, method, new[] {singleValue}, totalCount == 0 ? 1 : totalCount);
        
        /// <summary>
        ///   Creates and returns a failed outcome.
        /// </summary>
        /// <param name="method">
        ///   Sets the <see cref="Method"/>.
        /// </param>
        /// <returns>
        ///   An <see cref="HttpEnumOutcome{T}"/> to indicate failure and also carry a default
        ///   value of type <typeparamref name="T"/>.
        /// </returns>
        public static HttpEnumOutcome<T> Fail(HttpMethod method)
            => new HttpEnumOutcome<T>(false, method, default!, 0);
        
        /// <summary>
        ///   Creates and returns a failed outcome.
        /// </summary>
        /// <param name="method">
        ///   Sets the <see cref="Method"/>.
        /// </param>
        /// <param name="exception">
        ///   The <see cref="Exception"/> (presumably causing the failure).
        /// </param>
        /// <returns>
        ///   An <see cref="HttpEnumOutcome{T}"/> to indicate failure and also carry a default
        ///   value of type <typeparamref name="T"/>.
        /// </returns>
        public static HttpEnumOutcome<T> Fail(HttpMethod method, Exception exception) 
            => new HttpEnumOutcome<T>(false, method, default!, 0, exception);

        /// <summary>
        ///   Creates and returns a failed outcome.
        /// </summary>
        /// <param name="method">
        ///   Sets the <see cref="Method"/>.
        /// </param>
        /// <param name="value">
        ///   One or more items to populate the <see cref="Outcome{T}.Value"/>.
        /// </param>
        /// <param name="exception">
        ///   The <see cref="Exception"/> (presumably causing the failure).
        /// </param>
        /// <returns>
        ///   An <see cref="HttpEnumOutcome{T}"/> to indicate failure and also carry a default
        ///   value of type <typeparamref name="T"/>.
        /// </returns>
        /// <returns>
        ///   A <see cref="HttpEnumOutcome{T}"/> object.
        /// </returns>
        public static HttpEnumOutcome<T> Fail(HttpMethod method, T[] value, Exception exception) 
            => new(false, method, value, 0, exception);
        
        /// <summary>
        ///   A convenient overload method for passing a single value while creating and returning a failed outcome.
        /// </summary>
        /// <param name="method">
        ///   Sets the <see cref="Method"/>.
        /// </param>
        /// <param name="singleValue">
        ///   A single item to populate the <see cref="Outcome{T}.Value"/>.
        /// </param>
        /// <param name="exception">
        ///   The <see cref="Exception"/> (presumably causing the failure).
        /// </param>
        /// <returns>
        ///   An <see cref="HttpEnumOutcome{T}"/> to indicate failure and also carry a default
        ///   value of type <typeparamref name="T"/>.
        /// </returns>
        /// <returns>
        ///   A <see cref="HttpEnumOutcome{T}"/> object.
        /// </returns>
        public static HttpEnumOutcome<T> Fail(HttpMethod method, T singleValue, Exception exception) 
            => new(false, method, new[] { singleValue }, 0, exception);
        
        /// <summary>
        ///   Initialises the <see cref="HttpEnumOutcome{T}"/> object. 
        /// </summary>
        /// <param name="result">
        ///   Assigns the <see cref="Outcome.Result"/> (success/failure) flag.
        /// </param>
        /// <param name="method">
        ///   Initializes the <see cref="Method"/>.
        /// </param>
        /// <param name="value">
        ///   One or more items to populate the <see cref="Outcome{T}.Value"/>. Pass <c>null</c> if not applicable.
        /// </param>
        /// <param name="totalCount">
        ///   Initializes the <see cref="EnumOutcome{T}.TotalCount"/>. Pass zero (0) if not applicable.
        /// </param>
        /// <param name="exception">
        ///   Initializes the <see cref="Outcome.Exception"/>. Pass <c>null</c> if not applicable. 
        /// </param>
        protected HttpEnumOutcome(
            bool result, HttpMethod method, 
            IReadOnlyCollection<T> value, 
            int totalCount,
            Exception? exception = null)
        : base(result, value, totalCount, exception)
        {
            Method = method;
        }
    }
}