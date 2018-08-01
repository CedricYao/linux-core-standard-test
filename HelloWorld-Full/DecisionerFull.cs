using Autofac;

namespace HelloWorld_Full
{
    public class FullDecisioner : IFullDecisioner
    {
        public string DoWork()
        {
            return "Decisioner is doing full framework Work";
        }
    }

    public interface IFullDecisioner
    {
        string DoWork();
    }

    public class HelloWorldFullModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FullDecisioner>().As<IFullDecisioner>();
        }
    }
}
