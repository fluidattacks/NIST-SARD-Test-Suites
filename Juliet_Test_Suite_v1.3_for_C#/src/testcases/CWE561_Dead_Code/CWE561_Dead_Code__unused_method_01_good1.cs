/*
 * @description Bad class never uses the private function calculation, therefore, it is dead code.
 * 
 * */

using System;
using TestCaseSupport;

namespace testcases.CWE561_Dead_Code
{
    class CWE561_Dead_Code__unused_method_01_good1 : AbstractTestCaseClassIssueGood
    {
        public override object Clone()
        {
            return this.MemberwiseClone();
        }

        /* FIX: Good() method calls calculation() */
        private string calculation()
        {
            return "Calculation";
        }
#if (!OMITGOOD)
        public override void Good()
        {
            Good1();
        }

        private void Good1()
        {
            IO.WriteLine(calculation());
        }
#endif // OMITGOOD

}
}
