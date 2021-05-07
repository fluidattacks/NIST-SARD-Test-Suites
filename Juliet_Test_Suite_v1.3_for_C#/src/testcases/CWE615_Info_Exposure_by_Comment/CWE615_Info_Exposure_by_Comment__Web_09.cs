/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE615_Info_Exposure_by_Comment__Web_09.cs
Label Definition File: CWE615_Info_Exposure_by_Comment__Web.label.xml
Template File: point-flaw-09.tmpl.cs
*/
/*
* @description
* CWE: 615 Information Exposure by Comment
* Sinks:
*    GoodSink: no disclosure of username and password
*    BadSink : disclose username and password
* Flow Variant: 09 Control flow: if(IO.STATIC_READONLY_TRUE) and if(IO.STATIC_READONLY_FALSE)
*
* */

using TestCaseSupport;
using System;

using System.Web;
using System.IO;

namespace testcases.CWE615_Info_Exposure_by_Comment
{
class CWE615_Info_Exposure_by_Comment__Web_09 : AbstractTestCaseWeb
{
#if (!OMITBAD)
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        if (IO.STATIC_READONLY_TRUE)
        {
            /* FLAW: sensitive information exposed in client-side code comments */
            resp.Write("<!--DB username = joe, DB password = 123-->" +
                       "<form action=\"/test\" method=post>" +
                       "<input type=text name=dbusername>" +
                       "<input type=test name=dbpassword>" +
                       "<input type=submit value=Submit>" +
                       "</form>");
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes IO.STATIC_READONLY_TRUE to IO.STATIC_READONLY_FALSE */
    private void Good1(HttpRequest req, HttpResponse resp)
    {
        if (IO.STATIC_READONLY_FALSE)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            /* FIX: no info exposure in client-side code comments */
            resp.Write("<form action=\"/test\" method=post>" +
                       "<input type=text name=dbusername>" +
                       "<input type=test name=dbpassword>" +
                       "<input type=submit value=Submit>" +
                       "</form>");
        }
    }

    /* Good2() reverses the bodies in the if statement */
    private void Good2(HttpRequest req, HttpResponse resp)
    {
        if (IO.STATIC_READONLY_TRUE)
        {
            /* FIX: no info exposure in client-side code comments */
            resp.Write("<form action=\"/test\" method=post>" +
                       "<input type=text name=dbusername>" +
                       "<input type=test name=dbpassword>" +
                       "<input type=submit value=Submit>" +
                       "</form>");
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
