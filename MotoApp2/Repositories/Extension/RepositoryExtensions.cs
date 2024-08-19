using MotoApp2.Entities;
using MotoApp2.Repository;


namespace MotoApp2.Repositories.Extension;

public static class RepositoryExtensions
{
    public static void AddBach<T>(this IRepository<T> repository, T[] items) where T : class, IEntity
    {
        foreach (var emp in items)
        {
            repository.Add(emp) ;
        }
        repository.Save();
    }
}
