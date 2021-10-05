using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace TetraPak.AspNet
{
    public class ClaimsTransformationDispatcher : IClaimsTransformation
    {
        static IDictionary<string, ClaimsTransformationFactory> s_customClaimsTransformation;
        readonly IServiceProvider _serviceProvider;

        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            throw new System.NotImplementedException();
        }

        public ClaimsTransformationDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public static void AddCustomClaimsTransformation(IDictionary<string,ClaimsTransformationFactory>? customClaimsTransformation)
        {
            if (customClaimsTransformation is { })
            {
                s_customClaimsTransformation = customClaimsTransformation;
            }
        }
    }
}