namespace HotelBookingSystem.Api.Service;

/// <summary>
/// Interface for entity services
/// </summary>
public interface IService<T, DTO>
{
    /// <summary>
    /// Get all objects
    /// </summary>
    public IEnumerable<T> GetAll();

    /// <summary>
    /// Get an object by ID
    /// </summary>
    public T? GetById(int id);

    /// <summary>
    /// Creat an object
    /// </summary>
    public int Post(DTO postDto);

    /// <summary>
    /// Modify an existing object
    /// </summary>
    public T? Put(int id, DTO putDto);

    /// <summary>
    /// Delet an object
    /// </summary>
    public bool Delete(int id);
}