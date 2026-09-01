using LibraryManagement.App.Models;

namespace LibraryManagement.App.Interfaces;

/// <summary>
/// Defines borrowing and returning behavior.
/// </summary>
public interface IBorrowable
{
    /// <summary>
    /// Gets whether the item is currently borrowed.
    /// </summary>
    bool IsBorrowed { get; }

    /// <summary>
    /// Borrows the item for a member.
    /// </summary>
    void Borrow(Member member);

    /// <summary>
    /// Returns the item.
    /// </summary>
    void Return();
}