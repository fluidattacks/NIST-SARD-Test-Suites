/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE398_Code_Quality__equals_01.cs
Label Definition File: CWE398_Code_Quality.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 398 One of the 7 Pernicious Kingdoms - Code Quality
* Sinks: equals
*    GoodSink: Set a variable equal to another variable
*    BadSink : Setting a variable equal to itself has no effect
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE398_Code_Quality
{
class CWE398_Code_Quality__equals_01 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        int intOne = 1;
        IO.WriteLine(intOne);
        /* FLAW: The statement below has no effect since it is setting a variable to itself */
        intOne = intOne;
        IO.WriteLine(intOne);
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        Good1();
    }

    private void Good1()
    {
        int intOne = 1, intFive = 5;
        IO.WriteLine(intOne);
        /* FIX: Assign intFive to intOne */
        intOne = intFive;
        IO.WriteLine(intOne);
    }
#endif //omitgood
}
}
