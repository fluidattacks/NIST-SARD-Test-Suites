/*
 * @description Improper Locking
 * 
 * */

using System;
using System.Threading;
using TestCaseSupport;

namespace testcases.CWE667_Improper_Locking
{
    class CWE667_Improper_Locking__basic_01 : AbstractTestCase
    {
        static private int intBadNumber = 3;
        static private readonly object badLock = new object();

#if (!OMITBAD)
        public override void Bad()
        {
            Monitor.Enter(badLock);

            intBadNumber++;

            IO.WriteLine(intBadNumber);

            /* FLAW: lock is not unlocked */
        }
#endif // OMITBAD

        static private int intGood1Number = 3;
        static private readonly object goodLock = new object();

#if (!OMITGOOD)
        public void Good1()
        {
            Monitor.Enter(goodLock);

            try
            {
                intGood1Number++;

                IO.WriteLine(intGood1Number);
            }
            finally
            {
                /* FIX: Unlock the lock within a finally block */
                Monitor.Exit(goodLock);
            }
        }

        public override void Good()
        {
            Good1();
        }
#endif // OMITGOOD

}
}
