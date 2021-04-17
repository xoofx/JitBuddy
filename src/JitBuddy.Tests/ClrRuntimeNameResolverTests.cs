using System;
using NUnit.Framework;

namespace JitBuddy.Tests
{
    [TestFixture]
    public class ClrRuntimeNameResolverTests
    {
        [Test]
        public void ResolveSymbolTest()
        {
            var method = typeof(Foo).GetMethod("FooMethod");
            var result = method.ToAsm();
            Console.WriteLine(result);
            Assert.IsNotEmpty(result);
            Assert.That(result, Contains.Substring("JitBuddy.Tests.ClrRuntimeNameResolverTests+Bar.BarMethod()"));
        }

        class Foo
        {
            public void FooMethod(Bar b)
            {
                b.BarMethod();
            }
        }

        class Bar
        {
            public void BarMethod()
            {
            }
        }
    }
}