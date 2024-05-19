using System;
using UnityEngine;

namespace SourceCode.Core.InterfaceSerialization
{
    public class InterfaceSerializationAttribute : PropertyAttribute
    {
        public Type Type { get; }

        public InterfaceSerializationAttribute(Type type)
        {
            Type = type;
        }
    }
}