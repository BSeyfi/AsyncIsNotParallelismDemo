using System.Diagnostics;
using Asynchronous;

class Program
{
    public async static Task Main(string[] args)
    {
        //`RegularHeavyJobAsync` and `ParallelHeavyJobAsync` are two similar methods, but with the key distinction being the presence of parallelism in the latter. 
        var count = 1000000;
        var stp = Stopwatch.StartNew();
        
        stp.Start();
        await RegularHeavyJobAsync(count);
        stp.Stop();
        Console.WriteLine($"Elapsed Time with RegularHeavyJobAsyncAsync== {stp.ElapsedMilliseconds}");
        
        Console.WriteLine("---");
        
        stp.Restart();
        await ParralelHeavyJobAsync(count);
        stp.Stop();
        Console.WriteLine($"Elapsed Time with ParralelHeavyJobAsync== {stp.ElapsedMilliseconds}");
    }

    static async Task RegularHeavyJobAsync(int count)
    {
        long result = 0;

        for (int i = 0; i < 1000; i++)
        {
            result += await Task<int>.Run(() => Enumerable.Range(1, count).Sum(n => (int) Math.Log(n)));
        }

        Console.WriteLine($"summation equals to {result} ");
    }

    static async Task ParralelHeavyJobAsync(int count)
    {
        long result = 0;

        for (int i = 0; i < 1000; i++)
        {
            result += await Task<int>.Run(() => ParallelEnumerable.Range(1, count).Sum(n => (int) Math.Log(n)));
        }

        Console.WriteLine($"summation equals to {result} ");
    }
}