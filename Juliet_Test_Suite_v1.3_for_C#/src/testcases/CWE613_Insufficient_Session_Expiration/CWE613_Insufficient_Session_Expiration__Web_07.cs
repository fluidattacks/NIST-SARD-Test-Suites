/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE613_Insufficient_Session_Expiration__Web_07.cs
Label Definition File: CWE613_Insufficient_Session_Expiration__Web.label.xml
Template File: point-flaw-07.tmpl.cs
*/
/*
* @description
* CWE: 613 Insufficient Session Expiration
* Sinks:
*    GoodSink: force session to expire
*    BadSink : set session to never expire
* Flow Variant: 07 Control flow: if(privateFive==5) and if(privateFive!=5)
*
* */

using TestCaseSupport;
using System;

using System.Web;
using System.Web.SessionState;

namespace testcases.CWE613_Insufficient_Session_Expiration
{
class CWE613_Insufficient_Session_Expiration__Web_07 : AbstractTestCaseWeb
{
    /* The variable below is not declared "readonly", but is never assigned
     * any other value so a tool should be able to identify that reads of
     * this will always give its initialized value.
     */
    private int privateFive = 5;
#if (!OMITBAD)
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        if (privateFive == 5)
        {
            HttpContext ctx = HttpContext.Current;
            HttpSessionState session = ctx.Session;
            /* FLAW: A negative time indicates the session should never expire */
            session.Timeout = -1;
            resp.Write("Bad(): Session still valid");
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes privateFive==5 to privateFive!=5 */
    private void Good1(HttpRequest req, HttpResponse resp)
    {
        if (privateFive != 5)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            HttpContext ctx = HttpContext.Current;
            HttpSessionState session = ctx.Session;
            /* FIX: enforce an absolute session timeout of 60 seconds */
            session.Timeout = 1;
        }
    }

    /* Good2() reverses the bodies in the if statement */
    private void Good2(HttpRequest req, HttpResponse resp)
    {
        if (privateFive == 5)
        {
            HttpContext ctx = HttpContext.Current;
            HttpSessionState session = ctx.Session;
            /* FIX: enforce an absolute session timeout of 60 seconds */
            session.Timeout = 1;
        }
    }

    public override void Good(HttpRequest req, HttpResponse resp)
    {
        Good1(req, resp);
        Good2(req, resp);
    }
#endif //omitgood
}
}
