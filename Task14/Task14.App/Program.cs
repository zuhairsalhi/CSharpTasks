using System.Reflection;
using Task14.Services;

Console.WriteLine("=== Audit Log Scanner ===");
Console.WriteLine();

Assembly assembly = typeof(ProductService).Assembly;

foreach (Type type in assembly.GetTypes())
{
    foreach (MethodInfo method in type.GetMethods())
    {
        AuditLogAttribute? attribute =
            method.GetCustomAttribute<AuditLogAttribute>();

        if (attribute != null)
        {
            Console.WriteLine($"Class: {type.Name}");
            Console.WriteLine($"Method: {method.Name}");
            Console.WriteLine($"Description: {attribute.Description}");
            Console.WriteLine();
        }
    }
}