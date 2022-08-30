namespace DEDSEC.Domain.Services
{
    /// <summary>
    /// Сервис для операций с объектами базы данных
    /// </summary>
    /// <typeparam name="T">Тип объектов, с которыми будут выполняться операции</typeparam>
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(Guid id);
        Task<T> Create(T entity);
        Task<T> Update(Guid id, T entity);
        Task<bool> Delete(Guid id);
    }
}
