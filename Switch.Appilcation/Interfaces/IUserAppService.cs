using Switch.Appilcation.EventSourcedNormalizers;
using Switch.Appilcation.ViewModels;
using System;
using System.Collections.Generic;

namespace Switch.Appilcation.Interfaces
{
    public interface IUserAppService
    {
        IEnumerable<UserViewModel> GetAll();
        UserViewModel GetById(Guid id);
        void Register(UserViewModel customerViewModel);
        void Update(UserViewModel userViewModel);
        void Remove(Guid id);
        IList<UserHistoryData> GetAllHistory(Guid id);
    }
}
