using BenchmarkDotNet.Attributes;
using System;
[assembly: FastEnumToString(typeof(EnumBenchmark.Vehicles))]

namespace EnumBenchmark
{
    public enum Vehicles
    {
        car,
        bike,
        plane
    }

    [MemoryDiagnoser]
    public class Benchmarks
    {
        [Benchmark]
        public string NativeToString()
        {
            return Vehicles.bike.ToString();
        }

        [Benchmark]
        public string FastToString()
        {
            return FastToString(Vehicles.plane);
        }

        [Benchmark]
        public string EnumNameMethod()
        {
            return Enum.GetName(typeof(Vehicles), 1);
        }

        [Benchmark]
        public string EnumNameMethod2()
        {
            return Enum.GetName(Vehicles.car);
        }

        [Benchmark]
        public string ToStringFast()
        {
            return Vehicles.car.ToStringFast();
        }

        public static string FastToString(Vehicles states)
        {
            switch (states)
            {
                case Vehicles.car:
                    return nameof(Vehicles.car);
                case Vehicles.bike:
                    return nameof(Vehicles.bike);
                case Vehicles.plane:
                    return nameof(Vehicles.plane);
                default:
                    throw new ArgumentOutOfRangeException(nameof(states), states, null);
            }
        }
    }
}
