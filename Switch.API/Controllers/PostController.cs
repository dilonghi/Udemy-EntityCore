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
    public class PostController : ApiController
    {
        private readonly IPostAppService _postAppService;

        public PostController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator,
            IPostAppService postAppService) : base(notifications, mediator)
        {
            _postAppService = postAppService;
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("post/user/{id:guid}")]
        public IActionResult GetAllPostsByUserId(Guid id)
        {
            return Response(_postAppService.GetAllPostsByUserId(id));
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("post/group/{id:int}")]
        public IActionResult GetAllPostsByGroupId(int id)
        {
            return Response(_postAppService.GetAllPostsByGroupId(id));
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("post")]
        public IActionResult Get()
        {
            return Response(_postAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("post/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            return Response(_postAppService.GetById(id));

        }

        [HttpPost]
        [Route("post")]
        public IActionResult Post([FromBody]PostViewModel postViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(postViewModel);
            }

            _postAppService.Register(postViewModel);

            return Response(postViewModel);
        }

        //[HttpPut]
        //[Route("user-management")]
        //public IActionResult Put([FromBody]UserViewModel userViewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        NotifyModelStateErrors();
        //        return Response(userViewModel);
        //    }

        //    _userAppService.Update(userViewModel);

        //    return Response(userViewModel);
        //}

        //[HttpDelete]
        //[Route("user-management/{id:guid}")]
        //public IActionResult Delete(Guid id)
        //{
        //    _userAppService.Remove(id);

        //    return Response();
        //}


    }
}
