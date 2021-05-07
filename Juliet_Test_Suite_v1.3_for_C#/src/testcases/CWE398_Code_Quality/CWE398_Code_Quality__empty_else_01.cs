/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE398_Code_Quality__empty_else_01.cs
Label Definition File: CWE398_Code_Quality.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 398 One of the 7 Pernicious Kingdoms - Code Quality
* Sinks: empty_else
*    GoodSink: Else statement contains code
*    BadSink : An empty else statement has no effect
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE398_Code_Quality
{
class CWE398_Code_Quality__empty_else_01 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        int x;
        x = (new Random()).Next();
        if (x == 0)
        {
            IO.WriteLine("Inside the else statement");
        }
        /* FLAW: An empty else statement has no effect */
        else
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
        int x;
        x = (new Random()).Next();
        if (x == 0)
        {
            IO.WriteLine("Inside the if statement");
        }
        /* FIX: Do not include an empty else statement */
        else
        {
            IO.WriteLine("Inside the else statement");
        }
        IO.WriteLine("Hello from Good()");
    }
#endif //omitgood
}
}
