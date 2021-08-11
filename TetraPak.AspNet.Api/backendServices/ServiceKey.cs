using System;

namespace TetraPak.AspNet.Api
{
    class ServiceKey
    {
        readonly int _hashCode;

        #region .  Equality  .

        bool @equals(ServiceKey other) => other._hashCode == _hashCode;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && equals((ServiceKey) obj);
        }

        public override int GetHashCode() => _hashCode;

        #endregion

        public ServiceKey(object obj, Type type)
        {
            _hashCode = HashCode.Combine(obj.GetType().AssemblyQualifiedName, type);
        }
        
        public ServiceKey(Type type, string name)
        {
            _hashCode = HashCode.Combine(type.AssemblyQualifiedName, name);
        }
        
    }}