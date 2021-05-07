/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE209_Information_Leak_Error__StackTrace_01.cs
Label Definition File: CWE209_Information_Leak_Error.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 209 Information exposure through error message
* Sinks: StackTrace
*    GoodSink: Print generic error message to console
*    BadSink : Print stack trace to console
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE209_Information_Leak_Error
{
class CWE209_Information_Leak_Error__StackTrace_01 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        try
        {
            throw new InvalidOperationException();
        }
        catch (InvalidOperationException exceptInvalidOperationException)
        {
            IO.WriteLine(exceptInvalidOperationException.ToString()); /* FLAW: Print stack trace to console on error */
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        Good1();
    }

    private void Good1()
    {
        try
        {
            throw new InvalidOperationException();
        }
        catch (InvalidOperationException exceptInvalidOperationException)
        {
            IO.WriteLine("There was an invalid operation error"); /* FIX: print a generic message */
        }
    }
#endif //omitgood
}
}
