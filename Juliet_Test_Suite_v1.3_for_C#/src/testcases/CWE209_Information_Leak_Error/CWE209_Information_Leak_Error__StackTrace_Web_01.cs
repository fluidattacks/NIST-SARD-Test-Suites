/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE209_Information_Leak_Error__StackTrace_Web_01.cs
Label Definition File: CWE209_Information_Leak_Error.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 209 Information exposure through error message
* Sinks: StackTrace_Web
*    GoodSink: Print generic error message to console
*    BadSink : Print stack trace to console
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE209_Information_Leak_Error
{
class CWE209_Information_Leak_Error__StackTrace_Web_01 : AbstractTestCaseWeb
{
#if (!OMITBAD)
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        try
        {
            throw new InvalidOperationException();
        }
        catch (InvalidOperationException exceptInvalidOperationException)
        {
            resp.Write(exceptInvalidOperationException.ToString()); /* FLAW: Print stack trace in response on error */
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good(HttpRequest req, HttpResponse resp)
    {
        Good1(req, resp);
    }

    private void Good1(HttpRequest req, HttpResponse resp)
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
