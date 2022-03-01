namespace TetraPak.AspNet
{
    /// <summary>
    ///   used to express a comparison operation.
    /// </summary>
    public enum ScriptComparisonOperator
    {
        /// <summary>
        ///   No (recognized) comparison operation is expressed. 
        /// </summary>
        None,
        
        /// <summary>
        ///   Specifies the "is equal" operation.
        /// </summary>
        IsEqual,
        
        /// <summary>
        ///   Specifies the "is not equal" operation.
        /// </summary>
        NotEqual,

        /// <summary>
        ///   Specifies the "contains" operation.
        /// </summary>
        Contains,
        
        /// <summary>
        ///   Specifies the "not contains" operation.
        /// </summary>
        NotContains
    }
}