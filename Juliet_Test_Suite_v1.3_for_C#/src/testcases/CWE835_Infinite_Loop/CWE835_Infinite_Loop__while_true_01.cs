/*
 * @description Infinite loop - while(true)
 *
 * */

using System;
using TestCaseSupport;

namespace testcases.CWE835_Infinite_Loop
{
    class CWE835_Infinite_Loop__while_true_01 : AbstractTestCase
    {
#if (!OMITBAD)
        public override void Bad()
        {
            int i = 0;

            /* FLAW: Infinite Loop - while(true) with no break point */
            while (true)
            {
                IO.WriteLine(i);
                i++;
            }
        }
#endif // OMITBAD

#if (!OMITGOOD)
        private void Good1()
        {
            int i = 0;

            while (true)
            {
                /* FIX: Add a break point for the loop if i = 10 */
                if (i == 10)
                {
                    break;
                }
                IO.WriteLine(i);
                i++;
            }
        }

        public override void Good()
        {
            Good1();
        }
#endif // OMITGOOD

}
}
