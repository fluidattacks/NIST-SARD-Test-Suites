/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE615_Info_Exposure_by_Comment__Web_08.cs
Label Definition File: CWE615_Info_Exposure_by_Comment__Web.label.xml
Template File: point-flaw-08.tmpl.cs
*/
/*
* @description
* CWE: 615 Information Exposure by Comment
* Sinks:
*    GoodSink: no disclosure of username and password
*    BadSink : disclose username and password
* Flow Variant: 08 Control flow: if(PrivateReturnsTrue()) and if(PrivateReturnsFalse())
*
* */

using TestCaseSupport;
using System;

using System.Web;
using System.IO;

namespace testcases.CWE615_Info_Exposure_by_Comment
{
class CWE615_Info_Exposure_by_Comment__Web_08 : AbstractTestCaseWeb
{
    /* The methods below always return the same value, so a tool
     * should be able to figure out that every call to these
     * methods will return true or return false.
     */
    private static bool PrivateReturnsTrue()
    {
        return true;
    }

    private static bool PrivateReturnsFalse()
    {
        return false;
    }
#if (!OMITBAD)
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        if (PrivateReturnsTrue())
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
    /* Good1() changes PrivateReturnsTrue() to privateReturnsFalse() */
    private void Good1(HttpRequest req, HttpResponse resp)
    {
        if (PrivateReturnsFalse())
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
        if (PrivateReturnsTrue())
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
