/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE613_Insufficient_Session_Expiration__Web_01.cs
Label Definition File: CWE613_Insufficient_Session_Expiration__Web.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 613 Insufficient Session Expiration
* Sinks:
*    GoodSink: force session to expire
*    BadSink : set session to never expire
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

using System.Web;
using System.Web.SessionState;

namespace testcases.CWE613_Insufficient_Session_Expiration
{
class CWE613_Insufficient_Session_Expiration__Web_01 : AbstractTestCaseWeb
{
#if (!OMITBAD)
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        HttpContext ctx = HttpContext.Current;
        HttpSessionState session = ctx.Session;
        /* FLAW: A negative time indicates the session should never expire */
        session.Timeout = -1;
        resp.Write("Bad(): Session still valid");
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good(HttpRequest req, HttpResponse resp)
    {
        Good1(req, resp);
    }

    private void Good1(HttpRequest req, HttpResponse resp)
    {
        HttpContext ctx = HttpContext.Current;
        HttpSessionState session = ctx.Session;
        /* FIX: enforce an absolute session timeout of 60 seconds */
        session.Timeout = 1;
    }
#endif //omitgood
}
}
