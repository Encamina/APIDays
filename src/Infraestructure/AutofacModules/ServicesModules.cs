using Autofac;
using taller.Services;

namespace taller.Infraestructure.AutofacModules
{
    public class ServicesModules : Module 
    {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<StarWarsMockService>().As<IStarWarsService>();
    }
  }
}
