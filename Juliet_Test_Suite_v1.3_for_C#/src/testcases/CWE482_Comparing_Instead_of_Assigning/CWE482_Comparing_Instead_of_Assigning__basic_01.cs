/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE482_Comparing_Instead_of_Assigning__basic_01.cs
Label Definition File: CWE482_Comparing_Instead_of_Assigning__basic.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 482 Comparing Instead of Assigning
* Sinks:
*    GoodSink: Assigning
*    BadSink : Comparing instead of assigning
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE482_Comparing_Instead_of_Assigning
{
class CWE482_Comparing_Instead_of_Assigning__basic_01 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        int zeroOrOne = (new Random()).Next(2);
        bool isZero = false;
        if ((isZero == (zeroOrOne == 0)) == true) /* FLAW: should be (isZero = (zeroOrOne == 0)) */
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
        int zeroOrOne = (new Random()).Next(2);
        bool isZero = false;
        if ((isZero = (zeroOrOne == 0)) == true) /* FIX: correct assignment */
        {
            IO.WriteLine("zeroOrOne is 0");
        }
        IO.WriteLine("isZero is: " + isZero);
    }
#endif //omitgood
}
}
