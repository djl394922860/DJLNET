using DJLNET.Model.Entities;

namespace DJLNET.Repository.Interfaces
{
    public interface IUserRepository : IBaseReadOnlyRepository<User, int>
    {
        User GetAuthenticateUser(int id);
    }
}
