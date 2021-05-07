/*
 * @description Bad class never uses the private function calculation, therefore, it is dead code.
 * 
 * */

using System;
using TestCaseSupport;

namespace testcases.CWE561_Dead_Code
{
    class CWE561_Dead_Code__unused_method_01_bad : AbstractTestCaseClassIssueBad
    {
        public override object Clone()
        {
            return this.MemberwiseClone();
        }

        /* FLAW: This method is never called */
        private string calculation()
        {
            return "Calculation";
        }
#if (!OMITBAD)
        public override void Bad()
        {
            IO.WriteLine("hello");
        }
#endif // OMITBAD
}
}
