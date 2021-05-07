using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseSupport
{
    public abstract class AbstractTestCaseClassIssueBad : AbstractTestCaseBase, ICloneable
    {
#if (!OMITBAD)
        public abstract void Bad();
#endif //omitbad
        public abstract object Clone();

        public override void RunTest(string className)
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
