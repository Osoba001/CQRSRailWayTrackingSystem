using Microsoft.EntityFrameworkCore;
using RailWayInfrastructureLibrary.Data;
using RailWayModelLibrary.Entities.Base;
using RailWayModelLibrary.Repositories.Command.Base;
using System.Linq.Expressions;

namespace RailWayInfrastructureLibrary.Repository.Command.Base
{
    public class CommandRepo<T>:ICommandRepo<T> where T :class, IBaseModel
    {
        private readonly RailWayDbContext _context;
        public CommandRepo(RailWayDbContext context)
        {
            _context = context;
        }
        public virtual void AddEntity(T entity)
        {
            _context.Set<T>().AddAsync(entity);
        }
        //Remove
        public void RemoveById(Guid id)
        {
            var p = _context.Set<T>().FirstOrDefault(x=>x.Id==id);
            if (p != null)
            {
                _context.Remove(p);
            }
        }
        public void RomoveEntity(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        //update
        public void UpdateEntity(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public bool IfExist(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).Any();
        }
        public async Task SaveChanges()
        {
           await _context.SaveChangesAsync();
        }
    }
}
