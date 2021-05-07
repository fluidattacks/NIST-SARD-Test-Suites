using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseSupport
{
    public abstract class AbstractTestCaseBadOnly : AbstractTestCaseBase
    {
#if (!OMITBAD)
        /// <exception cref="Exception">This is where we would place a comment to alert an Exception can be thrown.</exception>
        public abstract void Bad();
#endif //omitbad

        override public void RunTest(String className)
        {
            Console.WriteLine("Starting tests for Class " + className);
#if (!OMITBAD)
            try
            {
                Bad();

                Console.WriteLine("Completed bad() for Class " + className);
            }
            catch (Exception throwableException)
            {
                Console.WriteLine("Caught a throwable from bad() for Class " + className);

                Console.WriteLine("Throwable's message = " + throwableException.Message);

                Console.WriteLine("Stack trace below");

                Console.WriteLine(throwableException.StackTrace);
            }
#endif //omitbad
        }
    }
}
