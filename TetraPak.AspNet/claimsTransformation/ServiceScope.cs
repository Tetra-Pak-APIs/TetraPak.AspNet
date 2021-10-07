namespace TetraPak.AspNet
{
    /// <summary>
    ///   Can be used to specify a scope when configuring (DI) services. 
    /// </summary>
    public enum ServiceScope
    {
        /// <summary>
        ///   Specifies a singleton service (initiated once and used globally).
        /// </summary>
        Singleton,

        /// <summary>
        ///   Specifies a scoped service (instantiated once per request/response roundtrip). 
        /// </summary>
        Scoped,
        
        /// <summary>
        ///   Specifies a transient service (instantiated every time requested by the service locator).
        /// </summary>
        Transient,
        
        /// <summary>
        ///  Service scope is unspecified.
        /// </summary>
        Unspecified
    }
}