/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE398_Code_Quality__empty_if_12.cs
Label Definition File: CWE398_Code_Quality.label.xml
Template File: point-flaw-12.tmpl.cs
*/
/*
* @description
* CWE: 398 One of the 7 Pernicious Kingdoms - Code Quality
* Sinks: empty_if
*    GoodSink: If statement contains code
*    BadSink : An empty if statement has no effect
* Flow Variant: 12 Control flow: if(IO.StaticReturnsTrueOrFalse())
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE398_Code_Quality
{
class CWE398_Code_Quality__empty_if_12 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        if (IO.StaticReturnsTrueOrFalse())
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
        }
        else
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
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes the "if" so that both branches use the GoodSink */
    private void Good1()
    {
        if (IO.StaticReturnsTrueOrFalse())
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
        }
        else
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
        }
    }

    public override void Good()
    {
        Good1();
    }
#endif //omitgood
}
}
