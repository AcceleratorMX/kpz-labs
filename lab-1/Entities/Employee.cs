using lab_1.Entities.Abstract;
using lab_1.Enums;
using lab_1.Interfaces;

namespace lab_1.Entities;

public class Employee : Entity, IEmployee, IInventoryable
{
    public EmployeePosition Position { get; }
    public DateTime HireDate { get; }
    public double Salary { get; private set; }

    public Employee(string name, EmployeePosition position, DateTime hireDate, double salary)
        : base(name)
    {
        if (salary < 0)
            throw new ArgumentException("Salary cannot be negative", nameof(salary));

        Position = position;
        HireDate = hireDate;
        Salary = salary;
    }

    public void GiveRaise(double amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Raise amount must be positive", nameof(amount));

        Salary += amount;
        Console.WriteLine($"{Name} received a raise of ${amount}. New salary: ${Salary}");
    }

    public string GetInventoryInfo()
    {
        return $"{ToString()}, Position: {Position}, Hired: {HireDate.ToShortDateString()}, Salary: ${Salary}";
    }
}