using MediatR;
using Switch.Domain.Commands.Inputs.Post;
using Switch.Domain.Core.Bus;
using Switch.Domain.Core.Notifications;
using Switch.Domain.Entities;
using Switch.Domain.Interfaces.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Switch.Domain.CommandHandlers
{
    public class PostCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewPostCommand, bool>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMediatorHandler Bus;

        public PostCommandHandler(IPostRepository postRepository,
                                    IUow uow,
                                    IMediatorHandler bus,
                                    INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _postRepository = postRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewPostCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var post = new Post(Guid.NewGuid(), message.Title, message.UserId, message.GroupId, message.ContentUrl);

            if (_postRepository.GetPostByTitleAndDateTime(post.Title, post.PublishDate) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The post is duplicated."));
                return Task.FromResult(false);
            }

            _postRepository.Add(post);

            Commit();

            return Task.FromResult(true);
        }

        //public Task<bool> Handle(UpdateUserCommand message, CancellationToken cancellationToken)
        //{
        //    if (!message.IsValid())
        //    {
        //        NotifyValidationErrors(message);
        //        return Task.FromResult(false);
        //    }

        //    //var name = new Name { FirstName = message.FirstName, LastName = message.LastName };
        //    //var email = new Email { Address = message.Email };
        //    var user = new User(message.Id, message.FirstName, message.LastName, message.Email, message.Mobile, message.Password, message.Birthdate, 
        //                        message.Sexo, message.ImageUrl);

        //    var existingCustomer = _userRepository.GetByEmail(user.Email);

        //    if (existingCustomer != null && existingCustomer.Id != user.Id)
        //    {
        //        if (!existingCustomer.Equals(user))
        //        {
        //            Bus.RaiseEvent(new DomainNotification(message.MessageType, "The customer e-mail has already been taken."));
        //            return Task.FromResult(false);
        //        }
        //    }

        //    _userRepository.Update(user);

        //    if (Commit())
        //    {
        //        Bus.RaiseEvent(new UserUpdatedEvent(user.Id, user.FirstName, user.LastName, user.Email,
        //                                            user.Mobile, user.Password, user.Birthdate, user.Sexo, user.ImageUrl));
        //    }

        //    return Task.FromResult(true);
        //}

        //public Task<bool> Handle(RemoveUserCommand message, CancellationToken cancellationToken)
        //{
        //    if (!message.IsValid())
        //    {
        //        NotifyValidationErrors(message);
        //        return Task.FromResult(false);
        //    }

        //    _userRepository.Remove(message.Id);

        //    if (Commit())
        //    {
        //        Bus.RaiseEvent(new UserRemoveEvent(message.Id));
        //    }

        //    return Task.FromResult(true);
        //}

        public void Dispose()
        {
            _postRepository.Dispose();
        }
    }
}
