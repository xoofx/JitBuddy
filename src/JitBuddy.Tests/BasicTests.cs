using NUnit.Framework;

namespace JitBuddy.Tests
{
    using System;
    using System.Runtime.CompilerServices;

    public class BasicTests
    {
        public static int AddMethod(int a, int b)
        {
            return a + b;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static float AddMethod2(float a, float b)
        {
            return a + b;
        }


        [Test]
        public void Test()
        {
            {
                var method = typeof(BasicTests).GetMethod("AddMethod");
                var result = method.ToAsm();
                Console.WriteLine(result);
                Assert.IsNotEmpty(result);
            }

            {
                var method = typeof(BasicTests).GetMethod("AddMethod2");
                var result = method.ToAsm();
                Console.WriteLine(result);
                Assert.IsNotEmpty(result);
            }
        }
    }
}