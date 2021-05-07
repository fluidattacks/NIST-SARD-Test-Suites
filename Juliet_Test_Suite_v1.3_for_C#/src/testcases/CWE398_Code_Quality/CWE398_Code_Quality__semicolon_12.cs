/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE398_Code_Quality__semicolon_12.cs
Label Definition File: CWE398_Code_Quality.label.xml
Template File: point-flaw-12.tmpl.cs
*/
/*
* @description
* CWE: 398 One of the 7 Pernicious Kingdoms - Code Quality
* Sinks: semicolon
*    GoodSink: Removed statement that has no effect
*    BadSink : A statement that has no effect
* Flow Variant: 12 Control flow: if(IO.StaticReturnsTrueOrFalse())
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE398_Code_Quality
{
class CWE398_Code_Quality__semicolon_12 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        if (IO.StaticReturnsTrueOrFalse())
        {
            ; /* FLAW: This semicolon is a statement that has no effect */
            IO.WriteLine("Hello from Bad()");
        }
        else
        {
            /* FIX: Do not include semicolon (statement that has no effect) */
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
            /* FIX: Do not include semicolon (statement that has no effect) */
            IO.WriteLine("Hello from Good()");
        }
        else
        {
            /* FIX: Do not include semicolon (statement that has no effect) */
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
