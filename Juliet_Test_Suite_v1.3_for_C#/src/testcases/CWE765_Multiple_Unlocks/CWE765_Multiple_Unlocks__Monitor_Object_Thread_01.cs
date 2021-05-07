/*
 * @description Demonstrates use of Monitor.Exit() more times than Monitor.Enter() in multithreaded code that accesses a shared variable.
 * 
 * */

using System;
using System.Threading;
using TestCaseSupport;

namespace testcases.CWE765_Multiple_Unlocks
{
    class CWE765_Multiple_Unlocks__Monitor_Object_Thread_01 : AbstractTestCase
    {
        /* Bad(): Use Monitor.Enter() once and Monitor.Exit() twice */
        static private readonly object badLock;
        static private int intBad = 1;

#if (!OMITBAD)
        public override void Bad()
        {
            Monitor.Enter(badLock);
            try
            {
                intBad = intBad * 2;
            }
            finally
            {
                Monitor.Exit(badLock);
                Monitor.Exit(badLock); /* FLAW: Code uses Monitor.Exit() twice (and Monitor.Enter() once), which will throw an SynchronizationLockException */
            }
        }
#endif // OMITBAD

        /* Good1(): Use a ReentrantLock properly (use Monitor.Enter() once and Monitor.Exit() once) */
        static private readonly object goodLock;
        static private int intGood1 = 1;

#if (!OMITGOOD)
        public void Good1()
        {
            Monitor.Enter(goodLock);
            try
            {
                intGood1 = intGood1 * 2;
            }
            finally
            {
                Monitor.Exit(goodLock); /* FIX: Only use Monitor.Exit() once */
            }
        }

        public override void Good()
        {
            Good1();
        }
#endif // OMITGOOD

}
}
