using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

#nullable enable

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Provides convenient extension methods for <see cref="HttpResponseMessage"/>s.
    /// </summary>
    public static class HttpResponseMessageHelper
    {
        /// <summary>
        ///   Produces an <see cref="Outcome{T}"/> object from a <see cref="HttpResponseMessage"/>.
        /// </summary>
        /// <param name="self">
        ///     The response message.
        /// </param>
        /// <param name="messageId">
        ///   (optional)<br/>
        ///   A unique string value for tracking a request/response (mainly for diagnostics purposes).
        /// </param>
        /// <returns>
        ///   An <see cref="Outcome{T}"/> to indicate success/failure and, on success, also carry
        ///   a <see cref="HttpResponseMessage"/> and, on failure, an <see cref="Exception"/>.
        /// </returns>
        public static async Task<Outcome<HttpResponseMessage>> ToOutcomeAsync(
            this HttpResponseMessage self,
            string? messageId)
            => self.IsSuccessStatusCode
                ? Outcome<HttpResponseMessage>.Success(self)
                : await responseOutcomeFailAsync(self, messageId);

        static async Task<Outcome<HttpResponseMessage>> responseOutcomeFailAsync(
            HttpResponseMessage self,
            string? messageId)
        {
            try
            {
                // try deserialize ApiErrorResponse ...
                var stream = await self.Content.ReadAsStreamAsync();
                var errorResponse = await JsonSerializer.DeserializeAsync<ApiErrorResponse>(stream);
                return  Outcome<HttpResponseMessage>.Fail(new ApiErrorResponseException(errorResponse));
            }
            catch
            {
                var message = await self.Content.ReadAsStringAsync();
                var errorResponse = new ApiErrorResponse("Error", messageId: messageId, description: message);
                return Outcome<HttpResponseMessage>.Fail(new ApiErrorResponseException(errorResponse));
            }
        }
    }
}