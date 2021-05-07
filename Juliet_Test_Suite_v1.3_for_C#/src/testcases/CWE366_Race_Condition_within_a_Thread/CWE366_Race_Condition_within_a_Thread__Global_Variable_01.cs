/*
 * @description Demonstrates a race condition in multithreaded code that accesses a globally shared variable.
 * 
 * */

using System;
using System.Threading;
using TestCaseSupport;

namespace testcases.CWE366_Race_Condition_within_a_Thread
{
    class CWE366_Race_Condition_within_a_Thread__Global_Variable_01 : AbstractTestCase
    {
        static private readonly object mainLock = new object();
        int result = 0;

        void Work_Bad()
        {
            for (int i = 0; i < 100000; i++)
            {
				/* FLAW: This global variable is accessed without a lock */
                result = result + 1;
            }
        }

#if (!OMITBAD)
        public override void Bad()
        {
            CWE366_Race_Condition_within_a_Thread__Global_Variable_01 badInst = new CWE366_Race_Condition_within_a_Thread__Global_Variable_01();
            Thread worker1 = new Thread(badInst.Work_Bad);
            Thread worker2 = new Thread(badInst.Work_Bad);
            Thread worker3 = new Thread(badInst.Work_Bad);
            worker1.Start();
            worker2.Start();
            worker3.Start();
            IO.WriteLine(badInst.result);
        }
#endif // OMITBAD

        void Work_Good()
        {
            for (int i = 0; i < 100000; i++)
            {
				/* FIX: Provide lock to protect the integrity of the global variable */
                Monitor.Enter(mainLock);
                result = result + 1;
                Monitor.Exit(mainLock);
            }
        }

#if (!OMITGOOD)
        public void Good1()
        {
            CWE366_Race_Condition_within_a_Thread__Global_Variable_01 goodInst = new CWE366_Race_Condition_within_a_Thread__Global_Variable_01();
            Thread worker1 = new Thread(goodInst.Work_Good);
            Thread worker2 = new Thread(goodInst.Work_Good);
            Thread worker3 = new Thread(goodInst.Work_Good);
            worker1.Start();
            worker2.Start();
            worker3.Start();
            IO.WriteLine(goodInst.result);
        }

        public override void Good()
        {
            Good1();
        }
#endif // OMITGOOD

}
}
