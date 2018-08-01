using Autofac;

namespace HelloWorld
{
    public class Decisioner : IDecisioner
    {
        public string DoSomeWork()
        {
            return "Decisioner is doing .net standard work";
        }
    }

    public interface IDecisioner
    {
        string DoSomeWork();
    }

    public class HelloWorldModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Decisioner>().As<IDecisioner>();
        }
    }
}
