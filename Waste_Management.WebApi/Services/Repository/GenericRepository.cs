using Microsoft.EntityFrameworkCore;
using Waste_Management.Data;
using Waste_Management.WebApi.Contracts.Repository;

namespace Waste_Management.WebApi.Services.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly Waste_ManagementDbContext _context;
        public GenericRepository(Waste_ManagementDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Get(int Id)
        {
            var Entity = await _context.Set<TEntity>().FindAsync(Id);
            return Entity;
        }

        public async Task<List<TEntity>> GetAll()
        {
            var Entities = await _context.Set<TEntity>().AsNoTrackingWithIdentityResolution().ToListAsync();
            return Entities;
        }

        public async Task Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
    }
}
