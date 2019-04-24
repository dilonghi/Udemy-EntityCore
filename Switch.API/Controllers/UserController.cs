using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Switch.Appilcation.Interfaces;
using Switch.Appilcation.ViewModels;
using Switch.Domain.Core.Bus;
using Switch.Domain.Core.Notifications;
using System;

namespace Switch.API.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserAppService _userAppService;

        public UserController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator,
            IUserAppService userAppService) : base(notifications, mediator)
        {
            _userAppService=userAppService;
    }

        [HttpGet]
        [AllowAnonymous]
        [Route("user-management")]
        [ResponseCache(Duration = 60)]
        public IActionResult Get()
        {
            return Response(_userAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("user-management/{id:guid}")]
        [ResponseCache(Duration = 10)]
        public IActionResult Get(Guid id)
        {
            return Response(_userAppService.GetById(id));

        }

        [HttpPost]
        [Route("user-management")]
        public IActionResult Post([FromBody]UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(userViewModel);
            }

            _userAppService.Register(userViewModel);

            return Response(userViewModel);
        }

        [HttpPut]
        [Route("user-management")]
        public IActionResult Put([FromBody]UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(userViewModel);
            }

            _userAppService.Update(userViewModel);

            return Response(userViewModel);
        }

        [HttpDelete]
        [Route("user-management/{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            _userAppService.Remove(id);

            return Response();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("user-management/history/{id:guid}")]
        public IActionResult History(Guid id)
        {
            var customerHistoryData = _userAppService.GetAllHistory(id);
            return Response(customerHistoryData);
        }
    }
}
