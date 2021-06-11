using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using TetraPak.Logging;

namespace TetraPak.AspNet.Debugging
{
    partial class LoggerHelper 
    {
        public static void Debug(this ILogger logger, HttpWebRequest request, string body = null)
        {
            if (logger is null || !logger.IsEnabled(LogLevel.Debug))
                return;
            
            var sb = new StringBuilder();
            sb.Append(request.Method.ToUpper());
            sb.Append(' ');
            sb.AppendLine(request.RequestUri.ToString());
            addHeaders(sb, request.Headers);
            addBody();
            logger.Debug(sb.ToString());
            
            void addBody()
            {
                if (request.Method == HttpMethods.Get)
                    return;
                
                if (body is {})
                {
                    sb.AppendLine();
                    sb.AppendLine(body);
                    return;
                }

                try
                {
                    using var stream = request.GetRequestStream();
                    using var reader = new StreamReader(stream);
                    body = reader.ReadToEnd();
                    sb.AppendLine();
                    sb.AppendLine(body);
                }
                catch (ProtocolViolationException)  { /* ignore */ }
            }
        }

        public static async Task Debug(this ILogger logger, HttpRequest request, string body = null)
        {
            if (logger is null)
                return;
            
            var sb = new StringBuilder();
            sb.Append(request.Method.ToUpper());
            sb.Append(' ');
            sb.AppendLine(request.GetDisplayUrl());
            addHeaders(sb, request.Headers);
            await addBody();
            logger.Debug(sb.ToString());
            
            async Task addBody()
            {
                if (body is {})
                {
                    sb.AppendLine();
                    sb.AppendLine(body);
                    return;
                }

                using var reader = new StreamReader(request.Body);
                body = await reader.ReadToEndAsync();
                if (string.IsNullOrEmpty(body))
                    return;
                
                sb.AppendLine();
                sb.AppendLine(body);
            }
        }

        public static void Debug(this ILogger logger, HttpWebResponse response, string body)
        {
            if (logger is null || response is null || !logger.IsEnabled(LogLevel.Debug))
                return;
            
            var sb = new StringBuilder();
            sb.Append((int) response.StatusCode);
            sb.Append(' ');
            sb.AppendLine(response.StatusCode.ToString());
            addHeaders(sb, response.Headers);
            if (body is null)
            {
                logger.Debug(sb.ToString());
                return;
            }

            sb.AppendLine();
            sb.Append(body);
            logger.Debug(sb.ToString());
        }
        
        static void addHeaders(StringBuilder sb, NameValueCollection headers)
        {
            foreach (string header in headers)
            {
                var value = headers[header];
                if (value is null)
                {
                    sb.AppendLine(header);
                    continue;
                }
            
                sb.Append(header);
                sb.Append('=');
                sb.AppendLine(value);
            }
        }
    
        static void addHeaders(StringBuilder sb, IHeaderDictionary headers)
        {
            foreach (var (key, values) in headers)
            {
                if (values.Count == 0)
                {
                    sb.AppendLine(key);
                    continue;
                }
            
                sb.Append(key);
                sb.Append('=');
                sb.AppendLine(values.ConcatCollection());
            }
        }
    }
}