using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace asyncDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("主线程:异步测试");
            GetValue();
            Console.WriteLine("我是主线程我回来了,主当前线程Id" + Thread.CurrentThread.ManagedThreadId);
            Console.ReadKey();
        }
        async static void GetValue()
        {
            Console.WriteLine("异步一开始");
            //主线程碰到await关键字以后 就会找到新线程执行await之后的所有代码，主线程回到之前的地方
            await Task.Run(()=> {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("异步执行中，当前线程Id" + Thread.CurrentThread.ManagedThreadId);
                }
            });
            Console.WriteLine("异步完成，当前线程Id"+Thread.CurrentThread.ManagedThreadId);
        }
    }
}
