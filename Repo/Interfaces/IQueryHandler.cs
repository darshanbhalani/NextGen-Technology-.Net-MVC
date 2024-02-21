using NextGen_Technology.Models;

namespace NextGen_Technology.Repo.Interfaces
{
    public interface IQueryHandler
    {
        void saveData(Query data);
        void sendEmailToClient(Query data);
        void sendEmailToAdmin();
    }
}
