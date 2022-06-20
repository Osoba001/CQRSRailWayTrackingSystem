using Microsoft.EntityFrameworkCore;
using RailWayInfrastructureLibrary.Data;
using RailWayModelLibrary.Entities.Base;
using RailWayModelLibrary.Repositories.Command.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
            try
            {
                _context.Set<T>().Remove(entity);
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
        //update
        public void UpdateEntity(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception)
            {

                throw new Exception();
            }
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
