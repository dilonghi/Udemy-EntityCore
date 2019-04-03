using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Switch.Domain.Core.Bus;
using Switch.Domain.Core.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Switch.API.Controllers
{
    public class UserController : ApiController
    {

        public UserController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("customer-management")]
        public IActionResult Get()
        {
            return Response();
        }
    }
}
