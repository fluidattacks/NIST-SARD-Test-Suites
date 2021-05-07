/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE615_Info_Exposure_by_Comment__Web_01.cs
Label Definition File: CWE615_Info_Exposure_by_Comment__Web.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 615 Information Exposure by Comment
* Sinks:
*    GoodSink: no disclosure of username and password
*    BadSink : disclose username and password
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

using System.Web;
using System.IO;

namespace testcases.CWE615_Info_Exposure_by_Comment
{
class CWE615_Info_Exposure_by_Comment__Web_01 : AbstractTestCaseWeb
{
#if (!OMITBAD)
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        /* FLAW: sensitive information exposed in client-side code comments */
        resp.Write("<!--DB username = joe, DB password = 123-->" +
                   "<form action=\"/test\" method=post>" +
                   "<input type=text name=dbusername>" +
                   "<input type=test name=dbpassword>" +
                   "<input type=submit value=Submit>" +
                   "</form>");
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good(HttpRequest req, HttpResponse resp)
    {
        Good1(req, resp);
    }

    private void Good1(HttpRequest req, HttpResponse resp)
    {
        /* FIX: no info exposure in client-side code comments */
        resp.Write("<form action=\"/test\" method=post>" +
                   "<input type=text name=dbusername>" +
                   "<input type=test name=dbpassword>" +
                   "<input type=submit value=Submit>" +
                   "</form>");
    }
#endif //omitgood
}
}
