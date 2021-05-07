/*
 * @description Infinite loop - for()
 *
 * */

using System;
using TestCaseSupport;

namespace testcases.CWE835_Infinite_Loop
{
    class CWE835_Infinite_Loop__for_01 : AbstractTestCase
    {
#if (!OMITBAD)
        public override void Bad()
        {
            int i = 0;

            /* FLAW: Infinite Loop - for() with no break point */
            for (i = 0; i >= 0; i = (i + 1) % 256)
            {
                IO.WriteLine(i);
            }
        }
#endif // OMITBAD

#if (!OMITGOOD)
        private void Good1()
        {
            int i = 0;

            for (i = 0; i >= 0; i = (i + 1) % 256)
            {
                /* FIX: Add a break point for the loop if i = 10 */
                if (i == 10)
                {
                    break;
                }
                IO.WriteLine(i);
            }
        }

        private void good2()
        {
            int i = 0;

            /* FIX: Add a break point for the loop if i = 10 */
            for (i = 0; i < 11; i = (i + 1) % 256)
            {
                IO.WriteLine(i);
            }
        }

        public override void Good()
        {
            Good1();
            good2();
        }
#endif // OMITGOOD

}
}
