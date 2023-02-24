namespace JWT_Auth_Data.Interfaces;

public interface IUnitOfWork
{
    Task CommmitAsync();

    void Commit();
}