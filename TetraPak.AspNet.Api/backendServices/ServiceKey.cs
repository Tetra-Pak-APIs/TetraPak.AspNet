using System;
using System.Diagnostics;

namespace TetraPak.AspNet.Api
{
    [DebuggerDisplay("{ToString()}")]
    class ServiceKey
    {
        readonly int _hashCode;
        
#if DEBUG
        readonly object _obj;

        readonly string _name;

        readonly Type _type;

        public override string ToString()
        {
            return _obj is { } 
                ? $"{_obj} | {_type}" 
                : $"{_type} | {_name}";
        }
#endif

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
#if DEBUG
            _obj = obj;
            _type = type;
#endif
        }
        
        public ServiceKey(Type type, string name)
        {
            _hashCode = HashCode.Combine(type.AssemblyQualifiedName, name);
#if DEBUG
            _type = type;
            _name = name;
#endif
        }
    }
}