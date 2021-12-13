using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Provides convenient methods for working with HTTP request objects.
    /// </summary>
    public static class HttpRequestHelper
    {
        /// <summary>
        ///   Clones the <see cref="HttpRequestMessage"/>. 
        /// </summary>
        /// <param name="message">
        ///   The <see cref="HttpRequestMessage"/> to be cloned.
        /// </param>
        /// <returns>
        ///   The cloned <see cref="HttpRequestMessage"/>.
        /// </returns>
        public static async Task<HttpRequestMessage> CloneAsync(this HttpRequestMessage message)
        {
            var clone = new HttpRequestMessage(message.Method, message.RequestUri)
            {
                Version = message.Version
            };
            
            // copy content via a MemoryStream ...
            var stream = new MemoryStream();
            if (message.Content is { })
            {
                await message.Content.CopyToAsync(stream).ConfigureAwait(false);
                stream.Position = 0;
                clone.Content = new StreamContent(stream);
                
                // copy content headers ...
                if (message.Content.Headers.Any())
                {
                    foreach (var (key, values) in message.Content.Headers)
                    {
                        clone.Content.Headers.Add(key, values);
                    }
                }
            }

#if NET5_0_OR_GREATER
            var clonedOptionsDictionary = (IDictionary<string, object?>)clone.Options;
            foreach (var (key, value) in message.Options)
            {
                clonedOptionsDictionary.Add(key, value);
            }
#else
            foreach (var (key, value) in message.Properties)
            {
                clone.Properties.Add(key, value);
            }
#endif
            foreach (var (key, values) in message.Headers)
            {
                clone.Headers.TryAddWithoutValidation(key, values);
            }

            return clone;
        }
    }
}