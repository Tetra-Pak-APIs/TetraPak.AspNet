using System;

namespace TetraPak.AspNet.Api.Mapping
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DtoMappingAttribute : Attribute
    {
        public DtoMappingStrategy Strategy { get; }

        public DtoMappingAttribute(DtoMappingStrategy strategy)
        {
            Strategy = strategy;
        }
    }
}