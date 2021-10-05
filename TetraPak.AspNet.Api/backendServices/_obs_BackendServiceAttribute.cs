using System;

namespace TetraPak.AspNet.Api 
{ 
    [AttributeUsage(AttributeTargets.Class)]
    public class BackendServiceAttribute : Attribute
    {
        public string ServiceName { get; set; }
        
        public BackendServiceAttribute(string serviceName)
        {
            ServiceName = string.IsNullOrWhiteSpace(serviceName)
                ? throw new ArgumentNullException(nameof(serviceName))
                : serviceName;
        }
    }
}