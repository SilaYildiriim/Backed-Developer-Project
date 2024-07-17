using Autofac;
using AutoMapper;
using Backed_Developer_Project.Application.AutoMapper;
using Backed_Developer_Project.Application.Services.FormFieldServices;
using Backed_Developer_Project.Application.Services.FormServices;
using Backed_Developer_Project.Application.Services.UserService;
using Backed_Developer_Project.Domain.Repositories;
using Backed_Developer_Project.InfraStructure.Repositories;

namespace Backed_Developer_Project.Application.IoC
{
    public class DependencyResolver : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepo>().As<IUserRepo>().InstancePerLifetimeScope();
            builder.RegisterType<FormRepo>().As<IFormRepo>().InstancePerLifetimeScope();
            builder.RegisterType<FormFieldRepo>().As<IFormFieldRepo>().InstancePerLifetimeScope();

            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<FormService>().As<IFormService>().InstancePerLifetimeScope();
            builder.RegisterType<FormFieldService>().As<IFormFieldService>().InstancePerLifetimeScope();

            builder.Register(context => new MapperConfiguration(config =>
            {
                config.AddProfile<Mapping>();
            })).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();

                return config.CreateMapper(context.Resolve);
            })
                .As<IMapper>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
