using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseSupport
{
    public abstract class AbstractTestCaseClassIssueGood : AbstractTestCaseBase, ICloneable
    {
#if (!OMITGOOD)
        public abstract void Good();
#endif //omitgood
        public abstract object Clone();

        public override void RunTest(string className)
        {
            Console.WriteLine("Starting tests for Class " + className);
#if (!OMITGOOD)
            try
            {
                Good();

                Console.WriteLine("Completed good() for Class " + className);
            }
            catch (Exception throwableException)
            {
                Console.WriteLine("Caught a throwable from good() for Class " + className);

                Console.WriteLine("Throwable's message = " + throwableException.Message);

                Console.WriteLine("Stack trace below");

                Console.WriteLine(throwableException.StackTrace);
            }
#endif //omitgood
        }
    }
}
