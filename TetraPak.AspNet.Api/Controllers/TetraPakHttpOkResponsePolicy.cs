using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace TetraPak.AspNet.Api.Controllers
{
    /// <summary>
    ///   The Tetra Pak default HTTP response policy. 
    /// </summary>
    public class TetraPakHttpOkResponsePolicy : IHttpOkResponsePolicy
    {
        /// <summary>
        ///   Gets or sets a value that specifies whether a "Created" (single) resource will be
        ///   reflected in response body (not in the "Locator" header). The default is <c>false</c>,
        ///   to comply with standard HTTP/REST principles.
        /// </summary>
        public bool ForceCreatedLocationInBody { get; set; }
        
        /// <inheritdoc />
        public OkObjectResult ApplyHttpResponsePolicy(HttpContext context, OkObjectResult response)
        {
            switch (context.Request.Method)
            {
                case "GET":
                    response.StatusCode = (int?)HttpOkStatusCode.OK;
                    return response;
                    
                case "POST":
                    if (tryApplyLocators())
                    {
                        response.StatusCode = (int?)HttpOkStatusCode.Created;
                    }
                    else
                    {
                        response.StatusCode = (int?)HttpOkStatusCode.OK;
                    }
                    return response;
                        
                case "PUT":
                    response.StatusCode = (int?)HttpOkStatusCode.Accepted;
                    return response;
                        
                case "PATCH":
                    response.StatusCode = (int?)HttpOkStatusCode.Accepted;
                    return response;
                    
                default:
                    return response;
            }
            
            bool tryApplyLocators()
            {
                if (response.Value is null)
                    return false;

                if (response.Value.TryAsApiDataResponse<object>(out var apiDataResponse))
                {
                    var array = apiDataResponse.GetDataAsObjectArray();
                    return array.Length switch
                    {
                        1 => tryApplyLocatorHeader(array[0]),
                        > 1 => tryApplyLocatorsInBody(array),
                        _ => false
                    };
                }

                return response.Value.IsCollectionOf<object>(out var items) 
                    ? tryApplyLocatorsInBody(items.ToArray())
                    : tryApplyLocatorHeader(response.Value);
            }

            bool tryApplyLocatorHeader(object item)
            {
                if (item is ResourceLocator locator)
                {
                    context.Response.Headers[HeaderNames.Location] = locator.Location;
                    return true;
                }

                if (!OnTryResolveResourceId(item, out var id)) 
                    return false;
                
                context.Response.Headers[HeaderNames.Location] = $"{context.Request.Path}/{id}";
                return true;
            }
            
            bool tryApplyLocatorsInBody(object[] items)
            {
                // todo consider resolving resource locators here
                return false;
            }
        }

        protected virtual bool OnTryResolveResourceId(object resource, out string id)
        {
            if (resource is IUniquelyIdentifiable identifiable)
            {
                id = identifiable.GetUniqueIdentity()?.ToString();
                return !string.IsNullOrEmpty(id);
            }

            // todo resolve resource id from [Key] attribute
            id = null;
            return false;
        }

       
    }
}