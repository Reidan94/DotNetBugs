using System.Diagnostics;
using System;

namespace StructureEqualsMeasurements
{
    struct LongStruct
    {
        long X;

        public override bool Equals(object obj)
        {
            return false;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }

    struct ByteStruct
    {
        byte X;

        public override bool Equals(object obj)
        {
            return false;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }

    struct LongStructInside
    {
        LongStruct A;
    }

    struct ByteStructInside
    {
        ByteStruct A;
    }

    
    struct BigStructInside
    {
        BiggerInnerStruct innerStruct;

        struct BiggerInnerStruct
        {
            BiggerInnerInnerStruct innerStruct;

            struct BiggerInnerInnerStruct
            {
                BiggerInnerInnerInnerStruct innerStruct;

                struct BiggerInnerInnerInnerStruct
                {
                    public override bool Equals(object obj)
                    {
                        return false;
                    }

                    public override int GetHashCode()
                    {
                        return 0;
                    }
                }

                public override bool Equals(object obj)
                {
                    return false;
                }

                public override int GetHashCode()
                {
                    return 0;
                }
            }

            public override bool Equals(object obj)
            {
                return false;
            }

            public override int GetHashCode()
            {
                return 0;
            }
        }
    }

    class Program
    {
        private const int ITERATION_NUMBER = 1000000;

        static double TestStruct<T>() where T : struct
        {
            var sw = new Stopwatch();
            var str = new T();

            sw.Start();
            for (var i = 0; i < ITERATION_NUMBER; i++)
                str.Equals(str);
            sw.Stop();

            return sw.ElapsedTicks / ITERATION_NUMBER;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("ByteStructInside: {0} ticks", TestStruct<ByteStructInside>());
            Console.WriteLine("LongStructInside: {0} ticks", TestStruct<LongStructInside>());
            Console.WriteLine("BigStructInside: {0} ticks", TestStruct<BigStructInside>());
        }
    }
}
