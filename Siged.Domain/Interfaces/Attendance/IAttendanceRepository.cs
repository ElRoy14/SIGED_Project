using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Domain.Interfaces.Attendance
{
    public interface IAttendanceRepository<TModel> where TModel : class
    {
        Task<IQueryable<TModel>> GetAllAttendanceAsync(Expression<Func<TModel, bool>> filter = null);
        Task<TModel> CheckIn(TModel model);
        Task<TModel> CheckOut(TModel model);
    }
}
