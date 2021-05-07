/*
 * @description Improper release of lock
 * 
 * */

using TestCaseSupport;

using System.Threading;

namespace testcases.CWE404_Improper_Resource_Shutdown
{
    class CWE404_Improper_Resource_Shutdown__Object_Lock_Thread_01 : AbstractTestCase
    {
        static private object badLock = new object();
        static private int intBadNumber = 3;
#if (!OMITBAD)
        static public void helperBad()
        {
            Monitor.Enter(badLock);

            intBadNumber++;

            IO.WriteLine(intBadNumber);

            /* FLAW: lock should be unlocked in a finally block */
            Monitor.Exit(badLock);
        }

        public override void Bad()
        {
            helperBad();
        }
#endif // OMITBAD
        static private int intGood1Number = 3;
        static private object goodLock = new object();
#if (!OMITGOOD)
        static public void helperGood1()
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

        public void Good1()
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
