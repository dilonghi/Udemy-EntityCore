namespace Switch.Domain.Interfaces.Repositories
{
    public interface IUow
    {
        bool Commit();
    }
}
