/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE617_Reachable_Assertion__length_12.cs
Label Definition File: CWE617_Reachable_Assertion.label.xml
Template File: point-flaw-12.tmpl.cs
*/
/*
* @description
* CWE: 617 Assertion is reachable
* Sinks: length
*    GoodSink: assert true, which will never trigger
*    BadSink : assert false, which will always trigger
* Flow Variant: 12 Control flow: if(IO.StaticReturnsTrueOrFalse())
*
* */

using TestCaseSupport;
using System;

using System.Diagnostics;

namespace testcases.CWE617_Reachable_Assertion
{
class CWE617_Reachable_Assertion__length_12 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        if (IO.StaticReturnsTrueOrFalse())
        {
            /* FLAW: assertion is false */
            Trace.Assert("".Length > 0);
        }
        else
        {
            /* FIX: assertion is true */
            Trace.Assert("cwe617".Length > 0);
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes the "if" so that both branches use the GoodSink */
    private void Good1()
    {
        if (IO.StaticReturnsTrueOrFalse())
        {
            /* FIX: assertion is true */
            Trace.Assert("cwe617".Length > 0);
        }
        else
        {
            /* FIX: assertion is true */
            Trace.Assert("cwe617".Length > 0);
        }
    }

    public override void Good()
    {
        Good1();
    }
#endif //omitgood
}
}
