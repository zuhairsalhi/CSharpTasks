using System;

namespace LibraryManagement.App.Attributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class AuditLogAttribute : Attribute
{
    public string Description { get; }

    public AuditLogAttribute(string description)
    {
        Description = description;
    }
}