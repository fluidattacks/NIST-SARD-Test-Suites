/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE398_Code_Quality__empty_if_16.cs
Label Definition File: CWE398_Code_Quality.label.xml
Template File: point-flaw-16.tmpl.cs
*/
/*
* @description
* CWE: 398 One of the 7 Pernicious Kingdoms - Code Quality
* Sinks: empty_if
*    GoodSink: If statement contains code
*    BadSink : An empty if statement has no effect
* Flow Variant: 16 Control flow: while(true)
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE398_Code_Quality
{
class CWE398_Code_Quality__empty_if_16 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        while(true)
        {
            int x;
            x = (new Random()).Next();
            /* FLAW: An empty if statement has no effect */
            if (x == 0)
            {
            }
            else
            {
                IO.WriteLine("Inside the else statement");
            }
            IO.WriteLine("Hello from Bad()");
            break;
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() change the conditions on the while statements */
    private void Good1()
    {
        while(true)
        {
            int x;
            x = (new Random()).Next();
            /* FIX: Do not include an empty if statement */
            if (x == 0)
            {
                IO.WriteLine("Inside the if statement");
            }
            else
            {
                IO.WriteLine("Inside the else statement");
            }
            IO.WriteLine("Hello from Good()");
            break;
        }
    }

    public override void Good()
    {
        Good1();
    }
#endif //omitgood
}
}
