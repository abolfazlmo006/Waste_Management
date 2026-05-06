namespace Waste_Management.WebApi.Contracts.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> Get(int Id);
        Task<TEntity> Add(TEntity entity);
        Task Update(TEntity entity);
    }
}
