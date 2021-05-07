/*
 * @description Infinite loop - while()
 *
 * */

using System;
using TestCaseSupport;

namespace testcases.CWE835_Infinite_Loop
{
    class CWE835_Infinite_Loop__while_01 : AbstractTestCase
    {
#if (!OMITBAD)
        public override void Bad()
        {
            int i = 0;

            /* FLAW: Infinite Loop - while() with no break point */
            while (i >= 0)
            {
                IO.WriteLine(i);
                i = (i + 1) % 256;
            }
        }
#endif // OMITBAD

#if (!OMITGOOD)
        private void Good1()
        {
            int i = 0;

            while (i >= 0)
            {
                /* FIX: Add a break point for the loop if i = 10 */
                if (i == 10)
                {
                    break;
                }
                IO.WriteLine(i);
                i = (i + 1) % 256;
            }
        }

        public override void Good()
        {
            Good1();
        }
#endif // OMITGOOD

}
}
