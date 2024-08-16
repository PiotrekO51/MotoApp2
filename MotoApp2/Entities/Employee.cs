
using System.Reflection;
using MotoApp2.Entities.Extensions;
namespace MotoApp2.Entities;

public class Employee : EntityBase
{

    public string? FirstName { get; set; }
    public string? SurName { get; set; }

    public override string ToString() => $"Id: {Id},  Imie:  {FirstName}, Nazwisko;  {SurName}";

}
