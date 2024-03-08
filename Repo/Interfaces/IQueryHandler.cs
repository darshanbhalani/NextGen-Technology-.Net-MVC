using NextGen_Technology.Models;
using NextGen_Technology.Repo.Classes;

namespace NextGen_Technology.Repo.Interfaces
{
    public interface IQueryHandler
    {
        Status saveData(Query data);
        void sendEmailToClient(Query data);
        void sendEmailToAdmin();
    }
}
