/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE643_Xpath_Injection__Environment_08.cs
Label Definition File: CWE643_Xpath_Injection.label.xml
Template File: sources-sinks-08.tmpl.cs
*/
/*
* @description
* CWE: 643 Xpath Injection
* BadSource: Environment Read data from an environment variable
* GoodSource: A hardcoded string
* Sinks:
*    GoodSink: validate input through SecurityElement.Escape
*    BadSink : user input is used without validate
* Flow Variant: 08 Control flow: if(PrivateReturnsTrue()) and if(PrivateReturnsFalse())
*
* */

using TestCaseSupport;
using System;

using System.Runtime.InteropServices;
using System.Xml.XPath;

using System.Web;

namespace testcases.CWE643_Xpath_Injection
{
class CWE643_Xpath_Injection__Environment_08 : AbstractTestCase
{

    /* The methods below always return the same value, so a tool
     * should be able to figure out that every call to these
     * methods will return true or return false. */
    private static bool PrivateReturnsTrue()
    {
        return true;
    }

    private static bool PrivateReturnsFalse()
    {
        return false;
    }
#if (!OMITBAD)
    public override void Bad()
    {
        string data;
        if (PrivateReturnsTrue())
        {
            /* get environment variable ADD */
            /* POTENTIAL FLAW: Read data from an environment variable */
            data = Environment.GetEnvironmentVariable("ADD");
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        if (PrivateReturnsTrue())
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
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodG2B1() - use goodsource and badsink by changing first PrivateReturnsTrue() to PrivateReturnsFalse() */
    private void GoodG2B1()
    {
        string data;
        if (PrivateReturnsFalse())
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        else
        {
            /* FIX: Use a hardcoded string */
            data = "foo";
        }
        if (PrivateReturnsTrue())
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
    }

    /* GoodG2B2() - use goodsource and badsink by reversing statements in first if */
    private void GoodG2B2()
    {
        string data;
        if (PrivateReturnsTrue())
        {
            /* FIX: Use a hardcoded string */
            data = "foo";
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        if (PrivateReturnsTrue())
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
    }

    /* goodB2G1() - use badsource and goodsink by changing second PrivateReturnsTrue() to PrivateReturnsFalse() */
    private void GoodB2G1()
    {
        string data;
        if (PrivateReturnsTrue())
        {
            /* get environment variable ADD */
            /* POTENTIAL FLAW: Read data from an environment variable */
            data = Environment.GetEnvironmentVariable("ADD");
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        if (PrivateReturnsFalse())
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
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
    }

    /* goodB2G2() - use badsource and goodsink by reversing statements in second if  */
    private void GoodB2G2()
    {
        string data;
        if (PrivateReturnsTrue())
        {
            /* get environment variable ADD */
            /* POTENTIAL FLAW: Read data from an environment variable */
            data = Environment.GetEnvironmentVariable("ADD");
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        if (PrivateReturnsTrue())
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
    }

    public override void Good()
    {
        GoodG2B1();
        GoodG2B2();
        GoodB2G1();
        GoodB2G2();
    }
#endif //omitgood
}
}
