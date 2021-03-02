using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Ninject.Extensions.Interception;

namespace redistest
{
    public class BaseInterceptor
    {
        public void SetColor()
        {
            int color = (int)Console.ForegroundColor + 1;
            if (color > 15) color = 0;
            Console.ForegroundColor = (ConsoleColor)color;
        }
    }
    public class LogInterceptor : BaseInterceptor, IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            this.SetColor();
            Console.WriteLine($"Pre-{invocation.Request.Method.Name} called");
            invocation.Proceed();
            this.SetColor();
            Console.WriteLine($"Post-{invocation.Request.Method.Name} called");
        }
    }
    public class AnotherLogInterceptor : BaseInterceptor, IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            this.SetColor();
            Console.WriteLine($"Another Log Pre-{invocation.Request.Method.Name} called");
            invocation.Proceed();
            this.SetColor();
            Console.WriteLine($"Another Log Post-{invocation.Request.Method.Name} called");
        }
    }
}
