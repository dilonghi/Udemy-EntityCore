using AutoMapper;
using AutoMapper.QueryableExtensions;
using Switch.Appilcation.Interfaces;
using Switch.Appilcation.ViewModels;
using Switch.Domain.Commands.Inputs.Post;
using Switch.Domain.Core.Bus;
using Switch.Domain.Interfaces.Repositories;
using Switch.Infra.Data.Repositories.EventSourcing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Switch.Appilcation.Services
{
    public class PostAppService : IPostAppService
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public PostAppService(IMapper mapper,
                              IPostRepository postRepository, 
                              IEventStoreRepository eventStoreRepository, 
                              IMediatorHandler bus)
        {
            _mapper = mapper;
            _postRepository = postRepository;
            _eventStoreRepository = eventStoreRepository;
            Bus = bus;
        }


        public IEnumerable<PostViewModel> GetAllPostsByUserId(Guid userId)
        {
            return _mapper.Map<IEnumerable<PostViewModel>>(_postRepository.GetAllPostsByUserId(userId).ToList());
        }

        public IEnumerable<PostViewModel> GetAllPostsByGroupId(int groupId)
        {
            return _mapper.Map<IEnumerable<PostViewModel>>(_postRepository.GetAllPostsByGroupId(groupId).ToList());
        }

        public IEnumerable<PostViewModel> GetAll()
        {
            return _postRepository.GetAll().ProjectTo<PostViewModel>(_mapper.ConfigurationProvider);
        }

        public PostViewModel GetById(Guid id)
        {
            return _mapper.Map<PostViewModel>(_postRepository.GetById(id));
        }

        public void Register(PostViewModel userViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewPostCommand>(userViewModel);
            Bus.SendCommand(registerCommand);
        }

        //public void Update(PostViewModel userViewModel)
        //{
        //    var updateCommand = _mapper.Map<PostViewModel>(userViewModel);
        //    Bus.SendCommand(updateCommand);
        //}

        //public void Remove(Guid id)
        //{
        //    var removeCommand = new RemoveUserCommand(id);
        //    Bus.SendCommand(removeCommand);
        //}

        

        public void Dispose()
        {
            _postRepository.Dispose();
            _eventStoreRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
