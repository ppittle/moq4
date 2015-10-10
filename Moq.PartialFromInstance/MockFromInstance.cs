using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moq.PartialFromInstance
{
    public class MockFromInstance<T> : Mock<T> where T : class 
    {
        public MockFromInstance(T instance, MockBehavior behavior = MockBehavior.Default)
            : base(behavior)
        {
            if (!typeof(T).IsInterface)
                throw new ArgumentException("This only works with interfaces at the moment.");
        }
    }

    public static class MockExtensions
    {
        private static object dynamicGenerationLock = new object();

        public static void SetupFromInstance<T>(this IMock<T> mock, T instnace)
            where T : class
        {
            if (!typeof(T).IsInterface)
                throw new ArgumentException("This only works with interfaces at the moment.");


        }

        private static void CompileCode(string code, object instance)
        {
            
        }
    }
}
