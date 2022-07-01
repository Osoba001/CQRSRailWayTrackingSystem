using Microsoft.EntityFrameworkCore;
using RailWayInfrastructureLibrary.Data;
using RailWayModelLibrary.Entities.Base;
using RailWayModelLibrary.Repositories.Query.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RailWayInfrastructureLibrary.Repository.Query.Base
{
    public class QueryRepo<T>:IQueryRepo<T> where T : class, IBaseModel
    {
        private readonly RailWayDbContext _context;
        public QueryRepo(RailWayDbContext context)
        {
            _context = context;
        }
       
        public async Task<IEnumerable<T>> FindByPredicate(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await _context.Set<T>().Where(predicate).ToListAsync();
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
        public async Task<IEnumerable<T>> GetTopN(int n)
        {
            return await _context.Set<T>().Take(n).ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
               return await _context.Set<T>().ToListAsync();
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public async Task<T> GetById(Guid id)
        {
            try
            {
                return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool IsExist(Guid id)
        {
            return _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id) != null;
        }

    }
}
