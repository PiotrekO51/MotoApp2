
namespace MotoApp2.Entities;

public class BusinesPartner: EntityBase
{
    public string? Name { get; set; }
    public override string ToString() => $"{Id},{Name}";
    public override string ToString2() => $"Id:{Id},  Imie:  {Name}";

}
