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
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }
        public async Task<IEnumerable<T>> GetTopN(int n)
        {
            return await _context.Set<T>().Take(n).ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }
        public bool IsExist(Guid id)
        {
            return _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id) != null;
        }

    }
}
