using System;

namespace Task14.Services
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AuditLogAttribute : Attribute
    {
        public string Description { get; }

        public AuditLogAttribute(string description)
        {
            Description = description;
        }
    }
}