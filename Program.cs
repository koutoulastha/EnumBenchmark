using BenchmarkDotNet.Running;

namespace EnumBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmarks>();
        }
    }    
}
