using System;
using System.Threading;

namespace learning_async
{
    class Program
    {
        static void Main(string[] args)
        {
            // Stopwatchクラス生成
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            //Console.WriteLine("Hello World!");
            int i = Calculate();

            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        static int Calculate()
        {
            int total = 0;
            for (int i = 1; i <= 100; ++i)
                total += i;
            Thread.Sleep(2500); // 何か重い処理をしている...
            return total;
        }
    }
}
