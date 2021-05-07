/*
 * @description statement always evaluates to true
 * 
 * */

using System;
using TestCaseSupport;

namespace testcases.CWE571_Expression_Always_True
{
    class CWE571_Expression_Always_True__string_equals_01 : AbstractTestCase
    {
#if (!OMITBAD)
        public override void Bad()
        {
            string stringTrue = "true";
            /* FLAW: always evaluates to true */
            if (stringTrue.Equals("true"))
            {
                IO.WriteLine("always prints");
            }
        }
#endif // OMITBAD

#if (!OMITGOOD)
        public override void Good()
        {
            Good1();
        }

        private void Good1()
        {
            string stringInput = "";
            IO.WriteLine("Enter a string: ");
            stringInput = Console.ReadLine();

            /* FIX: may evaluate to true or false */
            if (stringInput.Equals("true"))
            {
                IO.WriteLine("sometimes prints");
            }
        }
#endif // OMITGOOD

}
}
