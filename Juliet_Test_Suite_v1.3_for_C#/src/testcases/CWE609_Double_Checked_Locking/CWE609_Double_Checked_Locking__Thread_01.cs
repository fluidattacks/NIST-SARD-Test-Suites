/*
 * @description Use of "Double Checked Locking" which can fail in certain circumstances. 
 * 
 * */

using System;
using System.Threading.Tasks;
using TestCaseSupport;

namespace testcases.CWE609_Double_Checked_Locking
{
    class CWE609_Double_Checked_Locking__Thread_01 : AbstractTestCase
    {
        /* Bad() - Use of Double Checked Locking */
        private static string stringBad = null;
        private static readonly object badLock = new object();
#if (!OMITBAD)
        public static string helperBad()
        {
            if (stringBad == null)
            {
                lock (badLock)
                {
                    if (stringBad == null)
                    {
                        stringBad = "stringBad";
                    }
                }
            }
            return stringBad;
        }

        /* FLAW: Insufficient "Double-Checked Locking" in this method - in certain circumstances, this can lead to stringBad being initialized twice. */
        public override void Bad()
        {
            var task1 = Task.Run(() =>
            {
                IO.WriteLine(helperBad());
            });

            var task2 = Task.Run(() =>
            {
                IO.WriteLine(helperBad());
            });
        }
#endif // OMITBAD
        private volatile static string stringGood1 = null; /* FIX: Added "volatile" here */
        private static readonly object goodLock = new object();
#if (!OMITGOOD)
        public static string helperGood1()
        {
            if (stringGood1 == null)
            {
                lock (goodLock)
                {
                    if (stringGood1 == null)
                    {
                        stringGood1 = "stringGood1";
                    }
                }
            }
            return stringGood1;
        }

        public void Good1()
        {
            var task1 = Task.Run(() =>
            {
                IO.WriteLine(helperGood1());
            });

            var task2 = Task.Run(() =>
            {
                IO.WriteLine(helperGood1());
            });
        }

        private static string stringGood2 = null;

        public static string helperGood2() /* FIX: method avoids double checking */
        {
            if (stringGood2 == null)
            {
                stringGood2 = "stringGood2";
            }
            return stringGood2;
        }

        public void good2()
        {
            var task1 = Task.Run(() =>
            {
                IO.WriteLine(helperGood2());
            });

            var task2 = Task.Run(() =>
            {
                IO.WriteLine(helperGood2());
            });
        }

        public override void Good()
        {
            Good1();
            good2();
        }
#endif // OMITGOOD
}
}
