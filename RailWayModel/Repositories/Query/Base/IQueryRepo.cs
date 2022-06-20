using RailWayModelLibrary.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RailWayModelLibrary.Repositories.Query.Base
{
    public interface IQueryRepo<T> where T:IBaseModel
    {
        Task<IEnumerable<T>> FindByPredicate(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        bool IsExist(Guid id);
        Task<IEnumerable<T>> GetTopN(int n);
    }
}
