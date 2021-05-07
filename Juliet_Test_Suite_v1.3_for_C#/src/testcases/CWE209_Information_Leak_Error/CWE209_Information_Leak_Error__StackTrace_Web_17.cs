/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE209_Information_Leak_Error__StackTrace_Web_17.cs
Label Definition File: CWE209_Information_Leak_Error.label.xml
Template File: point-flaw-17.tmpl.cs
*/
/*
* @description
* CWE: 209 Information exposure through error message
* Sinks: StackTrace_Web
*    GoodSink: Print generic error message to console
*    BadSink : Print stack trace to console
* Flow Variant: 17 Control flow: for loops
*
* */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE209_Information_Leak_Error
{
class CWE209_Information_Leak_Error__StackTrace_Web_17 : AbstractTestCaseWeb
{
#if (!OMITBAD)
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        for(int j = 0; j < 1; j++)
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
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() use the GoodSinkBody in the for statement */
    private void Good1(HttpRequest req, HttpResponse resp)
    {
        for(int k = 0; k < 1; k++)
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
    }

    public override void Good(HttpRequest req, HttpResponse resp)
    {
        Good1(req, resp);
    }
#endif //omitgood
}
}
