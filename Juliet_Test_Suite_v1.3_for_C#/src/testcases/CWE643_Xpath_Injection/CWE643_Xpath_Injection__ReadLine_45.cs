/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE643_Xpath_Injection__ReadLine_45.cs
Label Definition File: CWE643_Xpath_Injection.label.xml
Template File: sources-sinks-45.tmpl.cs
*/
/*
 * @description
 * CWE: 643 Xpath Injection
 * BadSource: ReadLine Read data from the console using ReadLine()
 * GoodSource: A hardcoded string
 * Sinks:
 *    GoodSink: validate input through SecurityElement.Escape
 *    BadSink : user input is used without validate
 * Flow Variant: 45 Data flow: data passed as a private class member variable from one function to another in the same class
 *
 * */

using TestCaseSupport;
using System;

using System.Runtime.InteropServices;
using System.Xml.XPath;

using System.Web;

using System.IO;

namespace testcases.CWE643_Xpath_Injection
{
class CWE643_Xpath_Injection__ReadLine_45 : AbstractTestCase
{

    private string dataBad;
    private string dataGoodG2B;
    private string dataGoodB2G;
#if (!OMITBAD)
    private void BadSink()
    {
        string data = dataBad;
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

    public override void Bad()
    {
        string data;
        data = ""; /* Initialize data */
        {
            /* read user input from console with ReadLine */
            try
            {
                /* POTENTIAL FLAW: Read data from the console using ReadLine */
                data = Console.ReadLine();
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, exceptIO, "Error with stream reading");
            }
        }
        dataBad = data;
        BadSink();
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        GoodG2B();
        GoodB2G();
    }

    private void GoodG2BSink()
    {
        string data = dataGoodG2B;
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
    private void GoodG2B()
    {
        string data;
        /* FIX: Use a hardcoded string */
        data = "foo";
        dataGoodG2B = data;
        GoodG2BSink();
    }

    private void GoodB2GSink()
    {
        string data = dataGoodB2G;
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
    private void GoodB2G()
    {
        string data;
        data = ""; /* Initialize data */
        {
            /* read user input from console with ReadLine */
            try
            {
                /* POTENTIAL FLAW: Read data from the console using ReadLine */
                data = Console.ReadLine();
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, exceptIO, "Error with stream reading");
            }
        }
        dataGoodB2G = data;
        GoodB2GSink();
    }
#endif //omitgood
}
}
