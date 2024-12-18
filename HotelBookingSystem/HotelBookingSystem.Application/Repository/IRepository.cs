﻿namespace HotelBookingSystem.Application.Repository;

/// <summary>
/// Interface of basic data access methods
/// </summary>
public interface IRepository<T>
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
    public int Post(T entity);

    /// <summary>
    /// Modify an existing object
    /// </summary>
    public bool Put(T entity);

    /// <summary>
    /// Delete an object
    /// </summary>
    public bool Delete(int id);
}