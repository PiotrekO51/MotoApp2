
using System.Reflection;
using MotoApp2.Entities.Extensions;
namespace MotoApp2.Entities;

public class Employee : EntityBase
{
    List<Employee> _employees;
    public string? FirstName { get; set; }
    public string? SurName { get; set; }

    public override string ToString() => $"{Id},{FirstName},{SurName}";
    public override string ToString2() => $"Id:{Id},  Imie:  {FirstName},  Nazwisko:  {SurName}";

}
