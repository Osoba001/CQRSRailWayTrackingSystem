using RailWayModelLibrary.Entities.Base;
using System.Linq.Expressions;

namespace RailWayModelLibrary.Repositories.Command.Base
{
    public interface ICommandRepo<T> where T : IBaseModel
    {
        void AddEntity(T entity);
        void RomoveEntity(T entity);
        void UpdateEntity(T entity);
        bool IfExist(Expression<Func<T, bool>> predicate);
        void RemoveById(Guid id);
        Task SaveChanges();
    }
}
