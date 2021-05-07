/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE617_Reachable_Assertion__length_11.cs
Label Definition File: CWE617_Reachable_Assertion.label.xml
Template File: point-flaw-11.tmpl.cs
*/
/*
* @description
* CWE: 617 Assertion is reachable
* Sinks: length
*    GoodSink: assert true, which will never trigger
*    BadSink : assert false, which will always trigger
* Flow Variant: 11 Control flow: if(IO.StaticReturnsTrue()) and if(IO.StaticReturnsFalse())
*
* */

using TestCaseSupport;
using System;

using System.Diagnostics;

namespace testcases.CWE617_Reachable_Assertion
{
class CWE617_Reachable_Assertion__length_11 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        if (IO.StaticReturnsTrue())
        {
            /* FLAW: assertion is false */
            Trace.Assert("".Length > 0);
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* good1() changes IO.StaticReturnsTrue() to IO.StaticReturnsFalse() */
    private void Good1()
    {
        if (IO.StaticReturnsFalse())
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            /* FIX: assertion is true */
            Trace.Assert("cwe617".Length > 0);
        }
    }

    /* good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (IO.StaticReturnsTrue())
        {
            /* FIX: assertion is true */
            Trace.Assert("cwe617".Length > 0);
        }
    }

    public override void Good()
    {
        Good1();
        Good2();
    }
#endif //omitgood
}
}
