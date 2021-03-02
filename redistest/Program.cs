using System;
using Ninject;
using Ninject.Extensions.Interception.Infrastructure.Language;

namespace redistest
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Bind<ISMService>().To<SMService>().InSingletonScope();
            kernel.Intercept(x => true).With<LogInterceptor>();
            kernel.Intercept(x => true).With<AnotherLogInterceptor>();
            var service = kernel.Get<ISMService>();
            service.Run();
        }

        public void ReadData()
        {
            var cache = RedisManager.Connection.GetDatabase();
            var devicesCount = 10000;
            for (int i = 0; i < devicesCount; i++)
            {
                var value = cache.StringGet($"Device_Status:{i}");
                //Console.WriteLine($"Valor={value}");
            }
        }

        public void SaveBigData()
        {
            var devicesCount = 10000;
            var rnd = new Random();
            var cache = RedisManager.Connection.GetDatabase();

            for (int i = 1; i < devicesCount; i++)
            {
                var value = rnd.Next(0, 10000);
                cache.StringSet($"Device_Status:{i}", value);
            }
        }
    }
}
