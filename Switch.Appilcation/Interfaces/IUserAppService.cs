using Switch.Appilcation.ViewModels;
using System.Collections.Generic;

namespace Switch.Appilcation.Interfaces
{
    public interface IUserAppService
    {
        IEnumerable<UserViewModel> GetAll();
        void Register(UserViewModel customerViewModel);
    }
}
