using Autofac;
using CoreStandard.UI.Data;
using Microsoft.EntityFrameworkCore;

namespace CoreStandard.UI.IoC
{
    public class UiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CoreStandardDbContext>().As<DbContext>();
        }
    }
}