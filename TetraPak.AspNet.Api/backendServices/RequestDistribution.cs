namespace TetraPak.AspNet.Api
{
    /// <summary>
    ///   Used to specify the request thread distribution when performing multiple resource requests.
    /// </summary>
    public enum RequestDistribution
    {
        /// <summary>
        ///   Multiple requests are made in sequence (in same thread).
        /// </summary>
        Sequential,
        
        /// <summary>
        ///   Multiple requests are made in parallel (in worker threads).
        /// </summary>
        Parallel
    }
}