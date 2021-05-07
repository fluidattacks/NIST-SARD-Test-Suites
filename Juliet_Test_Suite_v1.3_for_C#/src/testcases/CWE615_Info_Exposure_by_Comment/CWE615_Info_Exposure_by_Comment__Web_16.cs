/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE615_Info_Exposure_by_Comment__Web_16.cs
Label Definition File: CWE615_Info_Exposure_by_Comment__Web.label.xml
Template File: point-flaw-16.tmpl.cs
*/
/*
* @description
* CWE: 615 Information Exposure by Comment
* Sinks:
*    GoodSink: no disclosure of username and password
*    BadSink : disclose username and password
* Flow Variant: 16 Control flow: while(true)
*
* */

using TestCaseSupport;
using System;

using System.Web;
using System.IO;

namespace testcases.CWE615_Info_Exposure_by_Comment
{
class CWE615_Info_Exposure_by_Comment__Web_16 : AbstractTestCaseWeb
{
#if (!OMITBAD)
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        while(true)
        {
            /* FLAW: sensitive information exposed in client-side code comments */
            resp.Write("<!--DB username = joe, DB password = 123-->" +
                       "<form action=\"/test\" method=post>" +
                       "<input type=text name=dbusername>" +
                       "<input type=test name=dbpassword>" +
                       "<input type=submit value=Submit>" +
                       "</form>");
            break;
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() change the conditions on the while statements */
    private void Good1(HttpRequest req, HttpResponse resp)
    {
        while(true)
        {
            /* FIX: no info exposure in client-side code comments */
            resp.Write("<form action=\"/test\" method=post>" +
                       "<input type=text name=dbusername>" +
                       "<input type=test name=dbpassword>" +
                       "<input type=submit value=Submit>" +
                       "</form>");
            break;
        }
    }

    public override void Good(HttpRequest req, HttpResponse resp)
    {
        Good1(req, resp);
    }
#endif //omitgood
}
}
