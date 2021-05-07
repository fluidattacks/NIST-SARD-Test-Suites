/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE613_Insufficient_Session_Expiration__Web_12.cs
Label Definition File: CWE613_Insufficient_Session_Expiration__Web.label.xml
Template File: point-flaw-12.tmpl.cs
*/
/*
* @description
* CWE: 613 Insufficient Session Expiration
* Sinks:
*    GoodSink: force session to expire
*    BadSink : set session to never expire
* Flow Variant: 12 Control flow: if(IO.StaticReturnsTrueOrFalse())
*
* */

using TestCaseSupport;
using System;

using System.Web;
using System.Web.SessionState;

namespace testcases.CWE613_Insufficient_Session_Expiration
{
class CWE613_Insufficient_Session_Expiration__Web_12 : AbstractTestCaseWeb
{
#if (!OMITBAD)
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        if (IO.StaticReturnsTrueOrFalse())
        {
            HttpContext ctx = HttpContext.Current;
            HttpSessionState session = ctx.Session;
            /* FLAW: A negative time indicates the session should never expire */
            session.Timeout = -1;
            resp.Write("Bad(): Session still valid");
        }
        else
        {
            HttpContext ctx = HttpContext.Current;
            HttpSessionState session = ctx.Session;
            /* FIX: enforce an absolute session timeout of 60 seconds */
            session.Timeout = 1;
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes the "if" so that both branches use the GoodSink */
    private void Good1(HttpRequest req, HttpResponse resp)
    {
        if (IO.StaticReturnsTrueOrFalse())
        {
            HttpContext ctx = HttpContext.Current;
            HttpSessionState session = ctx.Session;
            /* FIX: enforce an absolute session timeout of 60 seconds */
            session.Timeout = 1;
        }
        else
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
    }
#endif //omitgood
}
}
