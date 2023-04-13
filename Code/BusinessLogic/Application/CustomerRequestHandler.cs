using BusinessLogic.Entities.Users;

namespace BusinessLogic.Application
{
    public class CustomerRequestHandler
    {
        public IUser? CurrentUser { get; set; }
        public UserControlSystem? userControlSystem { get; internal set; }
        public CustomerRequestHandler()
        {
            CurrentUser= null;
            userControlSystem = null;
        }
    }
}