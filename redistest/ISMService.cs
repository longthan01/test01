using System;
using System.Collections.Generic;
using System.Text;

namespace redistest
{
    public interface ISMService
    {
        void Run();
    }

    public class SMService : BaseInterceptor, ISMService
    {
        public void Run()
        {
            this.SetColor();
            Console.WriteLine($"{nameof(Run)} called in {this.GetType().Name}");
        }
    }
}
