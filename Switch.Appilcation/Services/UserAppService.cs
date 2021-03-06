﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Switch.Appilcation.EventSourcedNormalizers;
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

        public UserViewModel GetById(Guid id)
        {
            return _mapper.Map<UserViewModel>(_userRepository.GetById(id));
        }

        public void Register(UserViewModel userViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewUserCommand>(userViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(UserViewModel userViewModel)
        {
            var updateCommand = _mapper.Map<UpdateUserCommand>(userViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveUserCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public IList<UserHistoryData> GetAllHistory(Guid id)
        {
            return UserHistory.ToJavaScriptCustomerHistory(_eventStoreRepository.All(id));
        }


        public void Dispose()
        {
            _userRepository.Dispose();
            _eventStoreRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
