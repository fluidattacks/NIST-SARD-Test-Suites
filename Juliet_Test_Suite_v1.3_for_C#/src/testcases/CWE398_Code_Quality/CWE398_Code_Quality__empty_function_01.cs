/*
 * @description call an empty function
 * 
 * */

using System;
using TestCaseSupport;

namespace testcases.CWE398_Code_Quality
{
    class CWE398_Code_Quality__empty_function_01 : AbstractTestCase
    {
#if (!OMITBAD)
        private void helperBad()
        {
            /* FLAW: Function does nothing */
        }

        public override void Bad()
        {
            helperBad();
        }
#endif // OMITBAD

#if (!OMITGOOD)
        private void helperGood1()
        {
            /* FIX: This function contains code */
            IO.WriteLine("helperGood1()");
        }

        private void Good1()
        {
            helperGood1();
        }

        public override void Good()
        {
            Good1();
        }
#endif // OMITGOOD
}
}
