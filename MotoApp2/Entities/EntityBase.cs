
namespace MotoApp2.Entities;

public abstract class EntityBase: IEntity
{
    public int Id { get; set; }
    public abstract string ToString2();

}
