using System.Net;

namespace TetraPak.AspNet.Api.Controllers
{
    /// <summary>
    ///   Contains the values of successful status codes defined for HTTP.
    /// </summary>
    public enum HttpOkStatusCode
    {
        /// <summary>
        ///   The request succeeded. The result meaning of "success" depends on the HTTP method:
        ///   <list type="table">
        ///     <listheader>
        ///       <term>Method</term>
        ///       <description>Description</description>
        ///     </listheader>
        ///     <item>
        ///       <term>
        ///         GET
        ///       </term>
        ///       <description>
        ///         The resource has been fetched and transmitted in the message body.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <term>
        ///         HEAD
        ///       </term>
        ///       <description>
        ///         The representation headers are included in the response without any message body.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <term>
        ///         PUT, POST PATCH
        ///       </term>
        ///       <description>
        ///         The resource describing the result of the action is transmitted in the message body.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <term>
        ///         TRACE
        ///       </term>
        ///       <description>
        ///         The message body contains the request message as received by the server.
        ///       </description>
        ///     </item>
        ///   </list>
        /// </summary>
        OK = HttpStatusCode.OK,
        
        /// <summary>
        ///   The request succeeded, and a new resource created as a result.
        ///   This is typically the response sent after POST requests, or some PUT requests.
        /// </summary>
        Created = HttpStatusCode.Created,
        
        /// <summary>
        ///   The request has been received but not yet acted upon. It is noncommittal,
        ///   since there is no way in HTTP to later send an asynchronous response indicating
        ///   the outcome of the request.
        ///   It is intended for cases where another process or server handles the request, or for batch processing.
        /// </summary>
        Accepted = HttpStatusCode.Accepted,
        
        /// <summary>
        ///   This response code means the returned metadata is not exactly the same as is available
        ///   from the origin server, but is collected from a local or a third-party copy.
        ///   This is mostly used for mirrors or backups of another resource.
        ///   Except for that specific case, the 200 OK response is preferred to this status.
        /// </summary>
        NonAuthoritativeInformation = HttpStatusCode.NonAuthoritativeInformation,
        
        /// <summary>
        ///   There is no content to send for this request, but the headers may be useful.
        ///   The user agent may update its cached headers for this resource with the new ones.
        /// </summary>
        NoContent = HttpStatusCode.NoContent,
        
        /// <summary>
        ///   Tells the user agent to reset the document which sent this request.
        /// </summary>
        ResetContent = HttpStatusCode.ResetContent,
        
        /// <summary>
        ///   This response code is used when the <see cref="HttpRequestHeader.Range"/> header is sent from the client
        ///   to request only part of a resource.
        /// </summary>
        PartialContent = HttpStatusCode.PartialContent,
        
        /// <summary>
        ///   Conveys information about multiple resources,
        ///   for situations where multiple status codes might be appropriate.
        /// </summary>
        MultiStatus = HttpStatusCode.MultiStatus,
        
        /// <summary>
        ///   Used inside a &lt;dav:propstat&gt; response element to avoid repeatedly enumerating
        ///   the internal members of multiple bindings to the same collection.
        /// </summary>
        AlreadyReported = HttpStatusCode.AlreadyReported,
        
        /// <summary>
        ///   The server has fulfilled a GET request for the resource, and the response is a representation
        ///   of the result of one or more instance-manipulations applied to the current instance.
        /// </summary>
        IMUsed = HttpStatusCode.IMUsed,
        
        /// <summary>
        ///   Indicates that the HTTP status code should be resolved automatically (see IHttpOkStatusResolver) 
        /// </summary>
        Auto = -1
    }
}