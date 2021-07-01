using System;

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Thrown to reflect configuration issues.
    /// </summary>
    public class ConfigurationException : Exception
    {
        public ConfigurationException(string message, Exception innerException = null)
        : base(message, innerException)
        {
        }
    }
}