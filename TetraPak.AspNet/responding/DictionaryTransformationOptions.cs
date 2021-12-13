using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TetraPak.DynamicEntities;

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Used to specify how to transform into an entity into a <see cref="IDictionary{TKey,TValue}"/>.
    /// </summary>
    /// <seealso cref="ApiErrorResponseHelper.ToDictionary"/>
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class DictionaryTransformationOptions
    {
        /// <summary>
        ///   Gets os sets a value that 
        ///   specifies the format to be used for value keys (eg. camelCase, kebab-case etc.).
        /// </summary>
        public KeyTransformationFormat KeyFormat { get; set; } = KeyTransformationFormat.CamelCase;

        /// <summary>
        ///   Gets os sets a value that 
        ///   specifies whether to skip <c>null</c> values.
        /// </summary>
        public bool IgnoreNullValues { get; set; }

        ///   Gets os sets a value that 
        ///   specifies whether to also transform reference type child values.
        public bool TransformChildren { get; set; } = false;

        /// <summary>
        ///   Gets a default <see cref="DictionaryTransformationOptions"/> object.
        /// </summary>
        public static DictionaryTransformationOptions Default => new();
    }
}