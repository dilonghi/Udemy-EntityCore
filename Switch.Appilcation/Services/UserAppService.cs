using AutoMapper;
using AutoMapper.QueryableExtensions;
using Switch.Appilcation.Interfaces;
using Switch.Appilcation.ViewModels;
using Switch.Domain.Commands.Inputs.User;
using Switch.Domain.Core.Bus;
using Switch.Domain.Interfaces.Repositories;
using Switch.Infra.Data.Repositories.EventSourcing;
using System;
using System.Collections.Generic;

namespace Switch.Appilcation.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public UserAppService(IMapper mapper, 
                              IUserRepository userRepository, 
                              IEventStoreRepository eventStoreRepository, 
                              IMediatorHandler bus)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _eventStoreRepository = eventStoreRepository;
            Bus = bus;
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            return _userRepository.GetAll().ProjectTo<UserViewModel>(_mapper.ConfigurationProvider);
        }

        public void Register(UserViewModel customerViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewUserCommand>(customerViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
