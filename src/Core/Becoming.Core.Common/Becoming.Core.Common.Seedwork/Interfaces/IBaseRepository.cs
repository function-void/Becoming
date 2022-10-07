namespace Becoming.Core.Common.Seedwork.Interfaces;

/// <summary>
/// This interfaces designed to working database model
/// </summary>
/// <typeparam name="Model">Database model</typeparam>
public interface IBaseRepository<Model> where Model : class
{
    /// <summary>
    /// This method with save changes of the inheritor "BaseContext" class
    /// </summary>
    /// <param name="id"></param>
    /// <param name="token"></param>
    /// <returns>Return result</returns>
    Task<int> DeleteAsync(Guid id, CancellationToken token = default);

    /// <summary>
    /// <para>This method without save changes</para>
    /// <para>Notes: After that, be sure to use the method save changes</para>
    /// </summary>
    /// <param name="model">Model for save or commit in database</param>
    void Delete(Model model);

    /// <summary>
    /// This method with save changes of the inheritor "BaseContext" class
    /// </summary>
    /// <param name="model"></param>
    /// <param name="token"></param>
    /// <returns>Return result</returns>
    Task<int> CreateAsync(Model model, CancellationToken token = default);

    /// <summary>
    /// <para>This method without save changes</para>
    /// <para>Notes: After that, be sure to use the method save changes</para>
    /// </summary>
    /// <param name="model">Model for save or commit in database</param>
    Task CreateAsync(Model model);

    /// <summary>
    /// This method with save changes of the inheritor "BaseContext" class
    /// </summary>
    /// <param name="changedDataModel"></param>
    /// <param name="token">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>Return result</returns>
    Task<int> SimpleUpdateAsync(Model changedDataModel, CancellationToken token = default);

    /// <summary>
    /// This method to used the base update in "BaseContext"
    /// <para>This method without save changes</para>
    /// <para>Notes: After that, be sure to use the method savechanges</para>
    /// </summary>
    /// <param name="changedDataModel">Model for save or commit in database</param>
    void SimpleUpdate(Model changedDataModel);

    Task<Model?> GetAsync(Guid id);

    IQueryable<Model> GetAllAsIQueryable();
}
