using System;
using System.Collections.Generic;

namespace TetraPak.AspNet.Api
{
    /// <summary>
    ///   Represents a service endpoint with issues.
    ///   The reason for such endpoints is to assist in creating meaningful error handling.
    /// </summary>
    public class ServiceInvalidEndpointUrl : ServiceEndpointUrl
    {
        IEnumerable<Exception> _issues;

        /// <summary>
        ///   Retrieves a request message id if available. 
        /// </summary>
        /// <param name="enforce">
        ///   (optional; default=<c>false</c>)<br/>
        ///   When set a message id will be generated and injected into the request/response context.
        /// </param>
        /// <returns>
        ///   A <see cref="string"/> value if a message id was available (or enforced); otherwise <c>null</c>.
        /// </returns>
        public string GetMessageId(bool enforce = false) => AmbientData.GetMessageId(enforce);

        /// <summary>
        ///   Retrieves all issues found for the invalid service endpoint URL.
        /// </summary>
        /// <returns>
        ///   A collection of <see cref="Exception"/>s.
        /// </returns>
        public IEnumerable<Exception> GetIssues() => _issues;

        internal ServiceInvalidEndpointUrl WithInformation(string name, IEnumerable<Exception> issues)
        {
            Name = name;
            StringValue = $"(name={name})"; 
            _issues = issues;
            return this;
        }

        /// <summary>
        ///   Initializes the <see cref="ServiceInvalidEndpointUrl"/>.
        ///   This constructor is mainly intended for the use by the dependency injection services. 
        /// </summary>
        /// <param name="ambientData">
        ///   An instance providing access to ambient date.
        /// </param>
        public ServiceInvalidEndpointUrl(AmbientData ambientData) 
        : base(ambientData)
        {
        }
    }
}