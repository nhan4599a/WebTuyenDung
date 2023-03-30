using System;

namespace WebTuyenDung.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AutoShortCircuitValidationFailedRequestAttribute : Attribute
    {
    }
}
