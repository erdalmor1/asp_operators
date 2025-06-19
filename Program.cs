using System;

// Top-level statements: no explicit Program class needed.
Console.WriteLine("Creating and comparing employees:\n");

Employee e1 = new(101, "Sarah",  "Wilson");
Employee e2 = new(101, "Michael","Brown");
Employee e3 = new(102, "Emma",   "Davis");

Console.WriteLine(e1);
Console.WriteLine(e2);
Console.WriteLine(e3);
Console.WriteLine();

Console.WriteLine($"e1 == e2 : {e1 == e2}");
Console.WriteLine($"e1 != e3 : {e1 != e3}");

try
{
    _ = new Employee(-1, "Invalid", "Employee");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"\nValidation Error: {ex.Message}");
}

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();


// ------------------------------------------------------------
// Local type definition used by the top-level code above
// ------------------------------------------------------------
public sealed class Employee
{
    public int    Id        { get; }
    public string FirstName { get; }
    public string LastName  { get; }

    public Employee(int id, string firstName, string lastName)
    {
        if (id <= 0)                    throw new ArgumentException("ID must be positive.",   nameof(id));
        if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentException("First name cannot be empty.", nameof(firstName));
        if (string.IsNullOrWhiteSpace(lastName))  throw new ArgumentException("Last name cannot be empty.",  nameof(lastName));

        Id        = id;
        FirstName = firstName.Trim();
        LastName  = lastName.Trim();
    }

    public override string ToString() =>
        $"Employee(ID: {Id}, Full Name: {FirstName} {LastName})";

    public static bool operator ==(Employee a, Employee b) =>
        a is null ? b is null : a.Id == b.Id;

    public static bool operator !=(Employee a, Employee b) => !(a == b);

    public override bool Equals(object? obj) =>
        obj is Employee e && Id == e.Id;

    public override int GetHashCode() => Id;
}
