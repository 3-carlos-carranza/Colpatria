namespace Data.Common.Definition
{
    public interface IUnitOfWork
    {
        void Commit();
        int CommitInt();
        void CommitAndRefreshChanges();
        void RollbackChanges();
    }
}