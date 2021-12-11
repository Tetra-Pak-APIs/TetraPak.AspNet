using System;
using System.Collections.Generic;
using System.IO;

#nullable enable

namespace TetraPak.AspNet.Debugging
{
    /// <summary>
    ///   An abstract representation of a HTTP request (note: the class itself is not <c>abstract</c>).
    /// </summary>
    public class AbstractHttpRequest
    {
        /// <summary>
        ///   Gets or sets a request URI.
        /// </summary>
        public Uri? Uri { get; set; }
        
        /// <summary>
        ///   Gets or sets a request HTTP method.
        /// </summary>
#pragma warning disable CS8618
        public string Method { get; set; }

        /// <summary>
        ///   Gets or sets the headers collection.
        /// </summary>
        public IEnumerable<KeyValuePair<string,IEnumerable<string>>> Headers { get; set; }
#pragma warning restore CS8618

        /// <summary>
        ///   Gets or sets a content (a.k.a. body).
        /// </summary>
        public Stream? Content { get; set; }
    }
}