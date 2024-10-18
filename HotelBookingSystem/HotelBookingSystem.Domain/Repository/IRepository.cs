namespace HotelBookingSystem.Domain.Repository;

/// <summary>
/// Интерфейс базовых методов доступа к данным
/// </summary>
public interface IRepository<T>
{
    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<T> GetAll();

    public T? GetById(int id);

    public void Post(T entity);

    public bool Put(T entity);

    public bool Delete(int id);
}
