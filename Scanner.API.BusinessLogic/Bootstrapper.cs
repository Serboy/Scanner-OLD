using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Scanner.API.BusinessLogic.Logics.Users;
using Scanner.API.BusinessLogic.Repositories.Users;
using Scanner.API.BusinessLogic.Services.Users;
using System;

namespace Scanner.API.BusinessLogic {
    public sealed class Bootstrapper {
        private static readonly Lazy<Bootstrapper> Instance = new Lazy<Bootstrapper>(() => new Bootstrapper());

        public static Bootstrapper Current => Instance.Value;
        private IServiceCollection Services { get; set; }

        public void Register(IServiceCollection services) {
            Services = services;

            Services.AddAutoMapper(typeof(Bootstrapper));
            RegisterLogic();
            RegisterServices();
            RegisterRepositories();
        }

        private void RegisterLogic() {
            Services.AddScoped<IUserLogic, UserLogic>();
        }

        private void RegisterRepositories() {
            Services.AddScoped<IUserRepo, UserRepo>();
        }

        private void RegisterServices() {
            Services.AddScoped<IUserService, UserService>();
        }
    }
}
