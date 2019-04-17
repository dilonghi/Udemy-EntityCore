using Switch.Appilcation.ViewModels;
using System;
using System.Collections.Generic;

namespace Switch.Appilcation.Interfaces
{
    public interface IPostAppService
    {
        IEnumerable<PostViewModel> GetAllPostsByUserId(Guid userId);
        IEnumerable<PostViewModel> GetAllPostsByGroupId(int groupId);
        IEnumerable<PostViewModel> GetAll();
        PostViewModel GetById(Guid id);
        void Register(PostViewModel postViewModel);
        //void Update(PostViewModel postViewModel);
        //void Remove(Guid id);
    }
}
