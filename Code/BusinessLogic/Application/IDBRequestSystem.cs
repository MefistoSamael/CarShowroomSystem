using BusinessLogic.Entities;
using BusinessLogic.Entities.Users;

namespace BusinessLogic.Application
{
    public interface IDBRequestSystem
    {
        void AddOrder(Order order);
        bool AddUser(IUser user);
        bool ChangeOrder(Guid id, Order order);
        bool ChangeUserInfo(string login, IUser user);
        bool DeleteUser(string userName);
        IUser? GetCertainUser(string userName);
        Order? GetOrder(Guid id);
    }

}