namespace LibraryManagement.App.Models;

/// <summary>
/// Represents the base class for people associated with the library.
/// </summary>
public abstract class Person
{
    /// <summary>
    /// Gets the person's unique identifier.
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Gets or sets the person's name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Initializes a person.
    /// </summary>
    protected Person(int id, string name)
    {
        if (id <= 0)
            throw new ArgumentException("ID must be greater than zero.");

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.");

        Id = id;
        Name = name;
    }

    /// <summary>
    /// Returns a string representation of the person.
    /// </summary>
    public override string ToString()
    {
        return $"{Id} - {Name}";
    }
}