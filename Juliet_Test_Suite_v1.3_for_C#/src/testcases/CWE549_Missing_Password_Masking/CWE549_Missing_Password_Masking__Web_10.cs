/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE549_Missing_Password_Masking__Web_10.cs
Label Definition File: CWE549_Missing_Password_Masking__Web.label.xml
Template File: point-flaw-10.tmpl.cs
*/
/*
* @description
* CWE: 549 Passwords should be masked during entry to prevent others from stealing them
* Sinks:
*    GoodSink: password field masked
*    BadSink : password field unmasked
* Flow Variant: 10 Control flow: if(IO.staticTrue) and if(IO.staticFalse)
*
* */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE549_Missing_Password_Masking
{
class CWE549_Missing_Password_Masking__Web_10 : AbstractTestCaseWeb
{
#if (!OMITBAD)
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        if (IO.staticTrue)
        {
            resp.Write("<form id=\"form\" name=\"form\" method=\"post\" action=\"password-test-web\">");
            resp.Write("Username: <input name=\"username\" type=\"text\" tabindex=\"10\" /><br><br>");
            /* FLAW: password field should be masked (type="text") */
            resp.Write("Password: <input name=\"password\" type=\"text\" tabindex=\"10\" />");
            resp.Write("<input type=\"submit\" name=\"submit\" value=\"Login-bad\" /></form>");
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* good1() changes IO.staticTrue to IO.staticFalse */
    private void Good1(HttpRequest req, HttpResponse resp)
    {
        if (IO.staticFalse)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            resp.Write("<form id=\"form\" name=\"form\" method=\"post\" action=\"password-test-web\">");
            resp.Write("Username: <input name=\"username\" type=\"text\" tabindex=\"10\" /><br><br>");
            /* FIX: password field is masked with type="password" instead of type="text" */
            resp.Write("Password: <input name=\"password\" type=\"password\" tabindex=\"10\" />");
            resp.Write("<input type=\"submit\" name=\"submit\" value=\"Login-good\" /></form>");
        }
    }

    /* good2() reverses the bodies in the if statement */
    private void Good2(HttpRequest req, HttpResponse resp)
    {
        if (IO.staticTrue)
        {
            resp.Write("<form id=\"form\" name=\"form\" method=\"post\" action=\"password-test-web\">");
            resp.Write("Username: <input name=\"username\" type=\"text\" tabindex=\"10\" /><br><br>");
            /* FIX: password field is masked with type="password" instead of type="text" */
            resp.Write("Password: <input name=\"password\" type=\"password\" tabindex=\"10\" />");
            resp.Write("<input type=\"submit\" name=\"submit\" value=\"Login-good\" /></form>");
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
