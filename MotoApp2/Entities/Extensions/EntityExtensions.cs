using MotoApp2;
using MotoApp2.Repositories;
using System.Text.Json;
namespace MotoApp2.Entities.Extensions;

public static class EntityExtensions
{
    public static T? Copy<T> (this T itemCopy) where T :  IEntity
    {
        var json = JsonSerializer.Serialize<T>(itemCopy);
        return JsonSerializer.Deserialize<T>(json);
    }

    
}
