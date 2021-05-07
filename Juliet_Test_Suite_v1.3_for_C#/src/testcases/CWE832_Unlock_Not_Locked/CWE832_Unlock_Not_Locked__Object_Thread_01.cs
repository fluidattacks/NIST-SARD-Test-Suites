/*
 * @description Demonstrates use of unlock() on a lock that is not locked in multithreaded code that accesses a shared variable.
 *
 * */

using System;
using System.Threading;
using System.Threading.Tasks;
using TestCaseSupport;

namespace testcases.CWE832_Unlock_Not_Locked
{
    class CWE832_Unlock_Not_Locked__Object_Thread_01 : AbstractTestCase
    {
#if (!OMITBAD)
        public override void Bad()
        {
            object lock1 = new object();
            object lock2 = new object();
            IO.WriteLine("Starting...");
            var task1 = Task.Run(() =>
            {
                Monitor.Enter(lock1);
                {
                    Thread.Sleep(1000);
                    IO.WriteLine("Finished Thread 1");
                }
                /* FLAW: Exiting (unlocking) a lock that is not locked. */
                Monitor.Exit(lock2);
            });

            Task.WaitAll(task1);
            IO.WriteLine("Finished...");
        }
#endif // OMITBAD

#if (!OMITGOOD)
        public void Good1()
        {
            object lock1 = new object();
            object lock2 = new object();
            IO.WriteLine("Starting...");
            var task1 = Task.Run(() =>
            {
                Monitor.Enter(lock1);
                {
                    Thread.Sleep(1000);
                    IO.WriteLine("Finished Thread 1");
                }
                /* FIX: Exiting (unlocking) a lock that is locked. */
                Monitor.Exit(lock1);
            });

            Task.WaitAll(task1);
            IO.WriteLine("Finished...");
        }

        public override void Good()
        {
            Good1();
        }
#endif // OMITGOOD

}
}
