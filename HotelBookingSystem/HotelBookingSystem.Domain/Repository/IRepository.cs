namespace HotelBookingSystem.Domain.Repository;

/// <summary>
/// Интерфейс базовых методов доступа к данным
/// </summary>
public interface IRepository<T>
{
    /// <summary>
    /// Получение всех объектов
    /// </summary>
    public IEnumerable<T> GetAll();

    /// <summary>
    /// Получение объекта по идентификатору
    /// </summary>
    public T? GetById(int id);

    /// <summary>
    /// Создание объекта
    /// </summary>
    public void Post(T entity);

    /// <summary>
    /// Изменение существующего объекта
    /// </summary>
    public bool Put(T entity);

    /// <summary>
    /// Удаление объекта
    /// </summary>
    public bool Delete(int id);
}