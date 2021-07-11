using System;
using System.Collections.Generic;

namespace TetraPak.AspNet.Api
{
    /// <summary>
    ///   Represents a service endpoint with issues.
    ///   The reason for such endpoints is to assist in creating meaningful error handling.
    /// </summary>
    public class ServiceInvalidEndpoint : ServiceEndpoint, IMessageIdProvider
    {
        IEnumerable<Exception> _issues;

        /// <inheritdoc />
        public string GetMessageId(bool enforce = false) => AmbientData.GetMessageId(enforce);

        /// <summary>
        ///   Retrieves all issues found for the invalid service endpoint URL.
        /// </summary>
        /// <returns>
        ///   A collection of <see cref="Exception"/>s.
        /// </returns>
        public IEnumerable<Exception> GetIssues() => _issues;

        internal ServiceInvalidEndpoint WithInformation(string name, IEnumerable<Exception> issues)
        {
            Name = name;
            StringValue = $"(name={name})"; 
            _issues = issues;
            return this;
        }

        /// <summary>
        ///   Initializes the <see cref="ServiceInvalidEndpoint"/>.
        ///   This constructor is mainly intended for the use by the dependency injection services. 
        /// </summary>
        /// <param name="ambientData">
        ///   An instance providing access to ambient date.
        /// </param>
        public ServiceInvalidEndpoint(AmbientData ambientData) 
        : base(ambientData)
        {
        }
    }
}