using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseSupport
{
    public abstract class AbstractTestCaseClassIssue : AbstractTestCaseBase, ICloneable
    {
        public abstract object Clone();

        protected AbstractTestCaseClassIssueBad badObject;

        protected AbstractTestCaseClassIssueGood goodObject;

        public override void RunTest(string className)
        {
            Console.WriteLine("Starting tests for Class " + className);
#if (!OMITGOOD)
            try
            {
                goodObject.Good();

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
#if (!OMITBAD)
            try
            {
                badObject.Bad();

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
