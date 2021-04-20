namespace TetraPak.AspNet.Api.Mapping
{
    public enum DtoMappingStrategy
    {
        /// <summary>
        ///   All values are included.
        /// </summary>
        All,
        
        /// <summary>
        ///   Only values that can be found in the map are included.
        /// </summary>
        MappedOnly,
        
        /// <summary>
        ///   Only values that can be mapped to a target property are included.
        /// </summary>
        PropertiesOnly,
        
        /// <summary>
        ///   No key --> key mapping. Assume mapping was already done and just convert.
        /// </summary>
        ConvertOnly
    }
}