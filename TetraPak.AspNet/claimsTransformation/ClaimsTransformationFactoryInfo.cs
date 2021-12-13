using System;

namespace TetraPak.AspNet
{
    class ClaimsTransformationFactoryInfo
    {
        public Type? Type { get; }

        public ClaimsTransformationFactory? ClaimsTransformationFactory { get; }

        public ClaimsTransformationFactoryInfo(Type type)
        {
            Type = type;
        }

        public ClaimsTransformationFactoryInfo(ClaimsTransformationFactory factory)
        {
            ClaimsTransformationFactory = factory;
        }
    }
}