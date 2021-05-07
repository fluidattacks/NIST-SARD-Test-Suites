/*
 * @description A class defines a readonly static array with public protection.
 * 
 * This is the "good" version, which has a private readonly static array.
 * 
 * */

using System;
using TestCaseSupport;

namespace testcases.CWE582_Array_Public_Readonly_Static
{
    class CWE582_Array_Public_Readonly_Static__basic_01_good1 : AbstractTestCaseClassIssueGood
    {
        private readonly static int[] INT_ARRAY = { 1, 2, 3, 4, 5 }; /* FIX: private, readonly, static */
#if (!OMITGOOD)
        private void Good1()
        {
            IO.WriteLine("INT_ARRAY[0]: " + CWE582_Array_Public_Readonly_Static__basic_01_good1.INT_ARRAY[0].ToString());
            CWE582_Array_Public_Readonly_Static__basic_01_good1.INT_ARRAY[0] = 2;
            IO.WriteLine("INT_ARRAY[0]: " + CWE582_Array_Public_Readonly_Static__basic_01_good1.INT_ARRAY[0].ToString());
        }

        public override void Good()
        {
            Good1();
        }
#endif // OMITGOOD

        /* This is here so that AbstractTestCaseClassIsssueGood implementation is satisfied */
        public override object Clone()
        {
            throw new NotImplementedException();
        }
}
}
