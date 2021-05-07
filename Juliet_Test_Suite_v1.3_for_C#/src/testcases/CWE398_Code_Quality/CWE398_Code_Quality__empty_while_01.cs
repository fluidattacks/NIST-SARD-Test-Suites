/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE398_Code_Quality__empty_while_01.cs
Label Definition File: CWE398_Code_Quality.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 398 One of the 7 Pernicious Kingdoms - Code Quality
* Sinks: empty_while
*    GoodSink: While statement contains code
*    BadSink : An empty while statement has no effect
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE398_Code_Quality
{
class CWE398_Code_Quality__empty_while_01 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        int i = 0;
        /* FLAW: An empty while statement has no effect */
        while(i++ < 10)
        {
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
        int i = 0;
        /* FIX: Do not include an empty while statement */
        while(i++ < 10)
        {
            IO.WriteLine("Inside the while statement");
        }
        IO.WriteLine("Hello from Good()");
    }
#endif //omitgood
}
}
