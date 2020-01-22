using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace learning_async
{
    class Program
    {
        static void Main(string[] args)
        {
            // Stopwatchクラス生成
            var sw = new System.Diagnostics.Stopwatch();

            Task<int> task = Task.Run(() => Calculate());
            var timer1 = new System.Timers.Timer(500);

            int cnt = 0;

            // タイマーの処理
            timer1.Elapsed += (sender, e) =>
            {
                if(task.Status == TaskStatus.RanToCompletion)
                {
                    int res = task.Result;
                    Console.WriteLine(res);
                    task.Start();
                }
                cnt++;
                Console.WriteLine(cnt);
            };

            timer1.Start();
            Console.ReadKey();
        }

        static int Calculate()
        {
            Console.WriteLine("task start");
            int total = 0;
            for (int i = 1; i <= 100; ++i)
                total += i;
            Thread.Sleep(2500); // 何か重い処理をしている...
            Console.WriteLine("task finish");
            return total;
        }
    }
}
