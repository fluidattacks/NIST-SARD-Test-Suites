/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE549_Missing_Password_Masking__Web_01.cs
Label Definition File: CWE549_Missing_Password_Masking__Web.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 549 Passwords should be masked during entry to prevent others from stealing them
* Sinks:
*    GoodSink: password field masked
*    BadSink : password field unmasked
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE549_Missing_Password_Masking
{
class CWE549_Missing_Password_Masking__Web_01 : AbstractTestCaseWeb
{
#if (!OMITBAD)
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        resp.Write("<form id=\"form\" name=\"form\" method=\"post\" action=\"password-test-web\">");
        resp.Write("Username: <input name=\"username\" type=\"text\" tabindex=\"10\" /><br><br>");
        /* FLAW: password field should be masked (type="text") */
        resp.Write("Password: <input name=\"password\" type=\"text\" tabindex=\"10\" />");
        resp.Write("<input type=\"submit\" name=\"submit\" value=\"Login-bad\" /></form>");
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good(HttpRequest req, HttpResponse resp)
    {
        Good1(req, resp);
    }

    private void Good1(HttpRequest req, HttpResponse resp)
    {
        resp.Write("<form id=\"form\" name=\"form\" method=\"post\" action=\"password-test-web\">");
        resp.Write("Username: <input name=\"username\" type=\"text\" tabindex=\"10\" /><br><br>");
        /* FIX: password field is masked with type="password" instead of type="text" */
        resp.Write("Password: <input name=\"password\" type=\"password\" tabindex=\"10\" />");
        resp.Write("<input type=\"submit\" name=\"submit\" value=\"Login-good\" /></form>");
    }
#endif //omitgood
}
}
