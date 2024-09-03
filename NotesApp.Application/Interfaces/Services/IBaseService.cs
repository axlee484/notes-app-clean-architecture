namespace NotesApp.Application.Interfaces;

public interface IBaseService<TRequest, TResponse>
{
    public Task<TResponse> AddAsync(TRequest entity);
    public Task<TResponse?> GetByIdAsync(int id);
    public Task<List<TResponse>> GetAsync();
}
