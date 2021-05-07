/*
 * @description Demonstrates a deadlock caused by obtaining locks in a different order in different functions in multithreaded code that accesses shared variables.
 * 
 * */

using System;
using System.Threading;
using System.Threading.Tasks;
using TestCaseSupport;

namespace testcases.CWE833_Deadlock
{
    class CWE833_Deadlock__Nested_Lock_Thread_01 : AbstractTestCase
    {
#if (!OMITBAD)
        public override void Bad()
        {
            object lock1 = new object();
            object lock2 = new object();
            IO.WriteLine("Starting...");
            var task1 = Task.Run(() =>
            {
                lock (lock1)
                {
                    Thread.Sleep(1000);
                    /* FLAW: 2nd thread acquires lock2 thus this thread cannot acquire it */
                    lock (lock2)
                    {
                        IO.WriteLine("Finished Thread 1");
                    }
                }
            });

            var task2 = Task.Run(() =>
            {
                lock (lock2)
                {
                    Thread.Sleep(1000);
                    /* FLAW: 1st thread acquires lock1 thus this thread cannot acquire it */
                    lock (lock1)
                    {
                        IO.WriteLine("Finished Thread 2");
                    }
                }
            });

            Task.WaitAll(task1, task2);
            IO.WriteLine("Finished...");
        }
#endif // OMITBAD

#if (!OMITGOOD)
        public void Good1()
        {
            object lock1 = new object();
            object lock2 = new object();
            IO.WriteLine("Starting...");
            /* FIX: nest the locks in the same order */
            var task1 = Task.Run(() =>
            {
                lock (lock1)
                {
                    Thread.Sleep(1000);
                    lock (lock2)
                    {
                        IO.WriteLine("Finished Thread 1");
                    }
                }
            });

            var task2 = Task.Run(() =>
            {
                lock (lock1)
                {
                    Thread.Sleep(1000);
                    lock (lock2)
                    {
                        IO.WriteLine("Finished Thread 2");
                    }
                }
            });

            Task.WaitAll(task1, task2);
            IO.WriteLine("Finished...");
        }

        public override void Good()
        {
            Good1();
        }
#endif // OMITGOOD

}
}
