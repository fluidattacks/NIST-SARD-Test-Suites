/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE481_Assigning_Instead_of_Comparing__basic_01.cs
Label Definition File: CWE481_Assigning_Instead_of_Comparing__basic.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 481 Assigning Instead of Comparing
* Sinks:
*    GoodSink: Comparing
*    BadSink : Assigning instead of comparing
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE481_Assigning_Instead_of_Comparing
{
class CWE481_Assigning_Instead_of_Comparing__basic_01 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        int zeroOrOne = (new Random()).Next(2);
        bool isZero = (zeroOrOne == 0);
        if (isZero = true) /* FLAW: should be == and INCIDENTIAL CWE 571 Expression Is Always True */
        {
            IO.WriteLine("zeroOrOne is 0");
        }
        IO.WriteLine("isZero is: " + isZero);
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        Good1();
    }

    private void Good1()
    {
        int zeroOrOne = (new Random()).Next(2); /* i will be 0 or 1 */
        bool isZero = (zeroOrOne == 0);
        if (isZero == true) /* FIX: using == instead of = */
        {
            IO.WriteLine("zeroOrOne is 0");
        }
        IO.WriteLine("isZero is: " + isZero);
    }
#endif //omitgood
}
}
