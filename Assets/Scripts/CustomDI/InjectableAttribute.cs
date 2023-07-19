using System;

namespace CustomDI
{
    [AttributeUsage(AttributeTargets.Method)]
    public class InjectableAttribute : Attribute
    {
        
    }
}