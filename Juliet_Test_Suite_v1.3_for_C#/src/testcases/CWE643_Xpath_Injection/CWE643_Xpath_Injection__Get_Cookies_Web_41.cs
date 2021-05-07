/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE643_Xpath_Injection__Get_Cookies_Web_41.cs
Label Definition File: CWE643_Xpath_Injection.label.xml
Template File: sources-sinks-41.tmpl.cs
*/
/*
 * @description
 * CWE: 643 Xpath Injection
 * BadSource: Get_Cookies_Web Read data from the first cookie using Cookies
 * GoodSource: A hardcoded string
 * Sinks:
 *    GoodSink: validate input through SecurityElement.Escape
 *    BadSink : user input is used without validate
 * Flow Variant: 41 Data flow: data passed as an argument from one method to another in the same class
 *
 * */

using TestCaseSupport;
using System;

using System.Runtime.InteropServices;
using System.Xml.XPath;

using System.Web;


namespace testcases.CWE643_Xpath_Injection
{
class CWE643_Xpath_Injection__Get_Cookies_Web_41 : AbstractTestCaseWeb
{
#if (!OMITBAD)
    private static void BadSink(string data , HttpRequest req, HttpResponse resp)
    {
        string xmlFile = null;
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            /* running on Windows */
            xmlFile = "..\\..\\CWE643_Xpath_Injection__Helper.xml";
        }
        else
        {
            /* running on non-Windows */
            xmlFile = "../../CWE643_Xpath_Injection__Helper.xml";
        }
        if (data != null)
        {
            /* assume username||password as source */
            string[] tokens = data.Split("||".ToCharArray());
            if (tokens.Length < 2)
            {
                return;
            }
            string username = tokens[0];
            string password = tokens[1];
            /* build xpath */
            XPathDocument inputXml = new XPathDocument(xmlFile);
            XPathNavigator xPath = inputXml.CreateNavigator();
            /* INCIDENTAL: CWE180 Incorrect Behavior Order: Validate Before Canonicalize
             *     The user input should be canonicalized before validation. */
            /* POTENTIAL FLAW: user input is used without validate */
            string query = "//users/user[name/text()='" + username +
                           "' and pass/text()='" + password + "']" +
                           "/secret/text()";
            string secret = (string)xPath.Evaluate(query);
        }
    }

    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        string data;
        data = ""; /* initialize data in case there are no cookies */
        /* Read data from cookies */
        {
            HttpCookieCollection cookieSources = req.Cookies;
            if (cookieSources != null)
            {
                /* POTENTIAL FLAW: Read data from the first cookie value */
                data = cookieSources[0].Value;
            }
        }
        BadSink(data , req, resp );
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good(HttpRequest req, HttpResponse resp)
    {
        GoodG2B(req, resp);
        GoodB2G(req, resp);
    }

    private static void GoodG2BSink(string data , HttpRequest req, HttpResponse resp)
    {
        string xmlFile = null;
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            /* running on Windows */
            xmlFile = "..\\..\\CWE643_Xpath_Injection__Helper.xml";
        }
        else
        {
            /* running on non-Windows */
            xmlFile = "../../CWE643_Xpath_Injection__Helper.xml";
        }
        if (data != null)
        {
            /* assume username||password as source */
            string[] tokens = data.Split("||".ToCharArray());
            if (tokens.Length < 2)
            {
                return;
            }
            string username = tokens[0];
            string password = tokens[1];
            /* build xpath */
            XPathDocument inputXml = new XPathDocument(xmlFile);
            XPathNavigator xPath = inputXml.CreateNavigator();
            /* INCIDENTAL: CWE180 Incorrect Behavior Order: Validate Before Canonicalize
             *     The user input should be canonicalized before validation. */
            /* POTENTIAL FLAW: user input is used without validate */
            string query = "//users/user[name/text()='" + username +
                           "' and pass/text()='" + password + "']" +
                           "/secret/text()";
            string secret = (string)xPath.Evaluate(query);
        }
    }

    /* goodG2B() - use goodsource and badsink */
    private static void GoodG2B(HttpRequest req, HttpResponse resp)
    {
        string data;
        /* FIX: Use a hardcoded string */
        data = "foo";
        GoodG2BSink(data , req, resp );
    }

    private static void GoodB2GSink(string data , HttpRequest req, HttpResponse resp)
    {
        string xmlFile = null;
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            /* running on Windows */
            xmlFile = "..\\..\\CWE643_Xpath_Injection__Helper.xml";
        }
        else
        {
            /* running on non-Windows */
            xmlFile = "../../CWE643_Xpath_Injection__Helper.xml";
        }
        if (data != null)
        {
            /* assume username||password as source */
            string[] tokens = data.Split("||".ToCharArray());
            if (tokens.Length < 2)
            {
                return;
            }
            /* FIX: validate input using StringEscapeUtils */
            string username = System.Security.SecurityElement.Escape(tokens[0]);
            string password = System.Security.SecurityElement.Escape(tokens[1]);
            /* build xpath */
            XPathDocument inputXml = new XPathDocument(xmlFile);
            XPathNavigator xPath = inputXml.CreateNavigator();
            string query = "//users/user[name/text()='" + username +
                           "' and pass/text()='" + password + "']" +
                           "/secret/text()";
            string secret = (string)xPath.Evaluate(query);
        }
    }

    /* goodB2G() - use badsource and goodsink */
    private static void GoodB2G(HttpRequest req, HttpResponse resp)
    {
        string data;
        data = ""; /* initialize data in case there are no cookies */
        /* Read data from cookies */
        {
            HttpCookieCollection cookieSources = req.Cookies;
            if (cookieSources != null)
            {
                /* POTENTIAL FLAW: Read data from the first cookie value */
                data = cookieSources[0].Value;
            }
        }
        GoodB2GSink(data , req, resp );
    }
#endif //omitgood
}
}
