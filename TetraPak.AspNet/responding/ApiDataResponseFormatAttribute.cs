using System;

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Used to automatically populate a response format version. 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ApiDataResponseFormatAttribute : Attribute
    {
        /// <summary>
        ///   Gets the API data response format version.
        /// </summary>
        public string Version { get; }

        /// <summary>
        ///   Initializes the <see cref="ApiDataResponseFormatAttribute"/>.
        /// </summary>
        public ApiDataResponseFormatAttribute(string version)
        {
            Version = version;
        }
    }
}