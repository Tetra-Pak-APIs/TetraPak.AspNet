using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;

namespace TetraPak.AspNet
{
    public static class HttpRequestMessageHelper
    {
        public static void TryAddHeadersFrom(this HttpRequestMessage message, HttpContent content)
        {
            if (!content.Headers.Any())
                return;

            foreach (var pair in content.Headers)
            {
                var existing = message.Headers.FirstOrDefault(p => p.Key.Equals(pair.Key));
                if (existing.Key is null)
                {
                    message.Headers.TryAddWithoutValidation(pair.Key, pair.Value);
                    continue;
                }

                var list = new List<string>(existing.Value);
                list.AddRange(pair.Value.Where(s => !existing.Value.Contains(s)).ToArray());
                message.Headers.Remove(existing.Key);
                message.Headers.TryAddWithoutValidation(existing.Key, list);
            }
        }
    }
}