/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE523_Unprotected_Cred_Transport__Web_12.cs
Label Definition File: CWE523_Unprotected_Cred_Transport__Web.label.xml
Template File: point-flaw-12.tmpl.cs
*/
/*
* @description
* CWE: 523 Unprotected Transport of Credentials
* Sinks: non_ssl
*    GoodSink: Send across SSL connection
*    BadSink : Send across non-SSL connection
* Flow Variant: 12 Control flow: if(IO.StaticReturnsTrueOrFalse())
*
* */

using TestCaseSupport;
using System;

using System.IO;

using System.Web;

namespace testcases.CWE523_Unprotected_Cred_Transport
{
class CWE523_Unprotected_Cred_Transport__Web_12 : AbstractTestCaseWeb
{
#if (!OMITBAD)
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        if (IO.StaticReturnsTrueOrFalse())
        {
            try
            {
                /* FLAW: transmitting login credentials across a non-SSL connection */
                resp.Write("<form action='http://hostname.com/j_security_check' method='post'>");
                resp.Write("<table>");
                resp.Write("<tr><td>Name:</td>");
                resp.Write("<td><input type='text' name='j_username'></td></tr>");
                resp.Write("<tr><td>Password:</td>");
                resp.Write("<td><input type='password' name='j_password' size='8'></td>");
                resp.Write("</tr>");
                resp.Write("</table><br />");
                resp.Write("<input type='submit' value='login'>");
                resp.Write("</form>");
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "There was a problem writing", exceptIO);
            }
        }
        else
        {
            try
            {
                /* FIX: ensure the connection is secure (https) */
                resp.Write("<form action='https://hostname.com/j_security_check' method='post'>");
                resp.Write("<table>");
                resp.Write("<tr><td>Name:</td>");
                resp.Write("<td><input type='text' name='j_username'></td></tr>");
                resp.Write("<tr><td>Password:</td>");
                resp.Write("<td><input type='password' name='j_password' size='8'></td>");
                resp.Write("</tr>");
                resp.Write("</table><br />");
                resp.Write("<input type='submit' value='login'>");
                resp.Write("</form>");
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "There was a problem writing", exceptIO);
            }
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes the "if" so that both branches use the GoodSink */
    private void Good1(HttpRequest req, HttpResponse resp)
    {
        if (IO.StaticReturnsTrueOrFalse())
        {
            try
            {
                /* FIX: ensure the connection is secure (https) */
                resp.Write("<form action='https://hostname.com/j_security_check' method='post'>");
                resp.Write("<table>");
                resp.Write("<tr><td>Name:</td>");
                resp.Write("<td><input type='text' name='j_username'></td></tr>");
                resp.Write("<tr><td>Password:</td>");
                resp.Write("<td><input type='password' name='j_password' size='8'></td>");
                resp.Write("</tr>");
                resp.Write("</table><br />");
                resp.Write("<input type='submit' value='login'>");
                resp.Write("</form>");
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "There was a problem writing", exceptIO);
            }
        }
        else
        {
            try
            {
                /* FIX: ensure the connection is secure (https) */
                resp.Write("<form action='https://hostname.com/j_security_check' method='post'>");
                resp.Write("<table>");
                resp.Write("<tr><td>Name:</td>");
                resp.Write("<td><input type='text' name='j_username'></td></tr>");
                resp.Write("<tr><td>Password:</td>");
                resp.Write("<td><input type='password' name='j_password' size='8'></td>");
                resp.Write("</tr>");
                resp.Write("</table><br />");
                resp.Write("<input type='submit' value='login'>");
                resp.Write("</form>");
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "There was a problem writing", exceptIO);
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
