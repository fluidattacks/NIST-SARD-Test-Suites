/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE398_Code_Quality__empty_case_01.cs
Label Definition File: CWE398_Code_Quality.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 398 One of the 7 Pernicious Kingdoms - Code Quality
* Sinks: empty_case
*    GoodSink: Case statement contains code
*    BadSink : An empty case statement has no effect
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE398_Code_Quality
{
class CWE398_Code_Quality__empty_case_01 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        int x = (new Random()).Next();
        switch (x)
        {
            /* FLAW: An empty case statement has no effect */
        case 0:
            break;
        default:
            IO.WriteLine("Inside the default statement");
            break;
        }
        IO.WriteLine("Hello from Bad()");
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        Good1();
    }

    private void Good1()
    {
        int x = (new Random()).Next();
        switch (x)
        {
            /* FIX: Do not include an empty case statement */
        case 0:
            IO.WriteLine("Inside the case statement");
            break;
        default:
            IO.WriteLine("Inside the default statement");
            break;
        }
        IO.WriteLine("Hello from Good()");
    }
#endif //omitgood
}
}
