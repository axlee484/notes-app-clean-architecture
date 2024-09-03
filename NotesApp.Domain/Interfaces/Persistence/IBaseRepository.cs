namespace NotesApp.Domain.Interfaces.Persistence;

public interface IBaseRepository<T>
{
    public Task<T> AddAsync(T entity);

    public Task<T?> GetByIdAsync(int id);
    public Task<List<T>> GetAsync();
}
