namespace Infrastructure.Persistences.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IClubRepository Club { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
