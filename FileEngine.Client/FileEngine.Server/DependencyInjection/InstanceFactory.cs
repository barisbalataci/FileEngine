using FileEngine.DataAccess.Abstract;
using FileEngine.DataAccess.Concrete;
using FileEngine.DataTypes.Concrete.Entities;
using FileEngine.Shared;
using Ninject;

namespace FileEngine.Server.DependencyInjection
{
    public class InstanceFactory<T>
    {
        //ninject is used for dependency injection by installed from Nuget
        public static T GetInstance()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IFileEngine>().To<FileEngine>().InSingletonScope();
            kernel.Bind<IDataService<Sievo>>().To<DataService<Sievo>>().InSingletonScope();

            return kernel.Get<T>();
        }
    }
}