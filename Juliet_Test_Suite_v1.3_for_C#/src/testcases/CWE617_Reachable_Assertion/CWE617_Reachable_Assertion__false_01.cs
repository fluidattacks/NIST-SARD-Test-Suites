/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE617_Reachable_Assertion__false_01.cs
Label Definition File: CWE617_Reachable_Assertion.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 617 Assertion is reachable
* Sinks: false
*    GoodSink: assert true, which will never trigger
*    BadSink : assert false, which will always trigger
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

using System.Diagnostics;

namespace testcases.CWE617_Reachable_Assertion
{
class CWE617_Reachable_Assertion__false_01 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        /* FLAW: this assertion can be reached, and will always trigger */
        Trace.Assert(false); /* INCIDENTAL: CWE 571 - expression is always true */
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        Good1();
    }

    private void Good1()
    {
        /* FIX: ensure assertions cannot be triggered, in this case, to avoid an empty
         * function, assert true */
        Trace.Assert(true); /* INCIDENTAL: CWE 570 - expression is always false */
    }
#endif //omitgood
}
}
