namespace HotelBookingSystem.Api.Service;

/// <summary>
/// Interface for entity services
/// </summary>
public interface IService<T, TDto>
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
    /// Create an object
    /// </summary>
    public int Post(TDto postDto);

    /// <summary>
    /// Modify an existing object
    /// </summary>
    public T? Put(int id, TDto putDto);

    /// <summary>
    /// Delete an object
    /// </summary>
    public bool Delete(int id);
}