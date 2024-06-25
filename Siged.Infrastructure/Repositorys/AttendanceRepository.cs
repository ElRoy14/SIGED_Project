using AutoMapper;
using Siged.Domain.Interfaces;
using Siged.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Infrastructure.Repositorys
{
    public class AttendanceRepository<TModel> : IAttendanceRepository<TModel> where TModel : class
    {
        private readonly DbSigedContext _dbContext;
        private readonly IMapper _mapper;

        public AttendanceRepository(DbSigedContext context)
        {
            _dbContext = context;
        }

        public async Task<TModel> CheckIn(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Add(model);
                await _dbContext.SaveChangesAsync();
                return model;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TModel> CheckOut(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Update(model);
                await _dbContext.SaveChangesAsync();
                return model;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IQueryable<TModel>> GetAllAttendanceAsync(Expression<Func<TModel, bool>> filter = null)
        {
            try
            {
                IQueryable<TModel> ModelQuery = filter == null ? _dbContext.Set<TModel>() : _dbContext.Set<TModel>().Where(filter);
                return ModelQuery;
            }
            catch
            {
                throw;
            }
        }

    }
}
