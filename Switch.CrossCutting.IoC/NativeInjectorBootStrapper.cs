using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Switch.Appilcation.Interfaces;
using Switch.Appilcation.Services;
using Switch.CrossCutting.Bus;
using Switch.Domain.CommandHandlers;
using Switch.Domain.Commands.Inputs.User;
using Switch.Domain.Core.Bus;
using Switch.Domain.Core.Events;
using Switch.Domain.Core.Notifications;
using Switch.Domain.EventHandlers;
using Switch.Domain.Events;
using Switch.Domain.Interfaces.Repositories;
using Switch.Infra.Data.Context;
using Switch.Infra.Data.EventSourcing;
using Switch.Infra.Data.Repositories;
using Switch.Infra.Data.Repositories.EventSourcing;
using Switch.Infra.Data.Uow;

namespace Switch.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            //services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application
            services.AddScoped<IUserAppService, UserAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<UserRegisteredEvent>, UserEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewUserCommand, bool>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateUserCommand, bool>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveUserCommand, bool>, UserCommandHandler>();

            // Infra - Data
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUow, Uow>();
            services.AddScoped<SwitchContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();


            // Infra - Identity
            //services.AddScoped<IUser, AspNetUser>();
        }
    }
}
