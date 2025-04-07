namespace TaskMasterAPI.Interfaces.Repositories;

public interface IUnitOfWork : IDisposable
{
    ITaskRepository Tasks { get; }
    Task<int> CompleteAsync();
}

