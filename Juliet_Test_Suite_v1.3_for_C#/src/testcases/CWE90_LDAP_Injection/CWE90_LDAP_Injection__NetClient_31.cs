/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE90_LDAP_Injection__NetClient_31.cs
Label Definition File: CWE90_LDAP_Injection.label.xml
Template File: sources-sink-31.tmpl.cs
*/
/*
 * @description
 * CWE: 90 LDAP Injection
 * BadSource: NetClient Read data from a web server with WebClient
 * GoodSource: A hardcoded string
 * Sinks:
 *    BadSink : data concatenated into LDAP search, which could result in LDAP Injection
 * Flow Variant: 31 Data flow: make a copy of data within the same method
 *
 * */

using TestCaseSupport;
using System;

using System.DirectoryServices;

using System.Web;

using System.IO;
using System.Net;

namespace testcases.CWE90_LDAP_Injection
{

class CWE90_LDAP_Injection__NetClient_31 : AbstractTestCase
{
#if (!OMITBAD)
    /* uses badsource and badsink */
    public override void Bad()
    {
        string dataCopy;
        {
            string data;
            data = ""; /* Initialize data */
            /* read input from WebClient */
            {
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        using (StreamReader sr = new StreamReader(client.OpenRead("http://www.example.org/")))
                        {
                            /* POTENTIAL FLAW: Read data from a web server with WebClient */
                            /* This will be reading the first "line" of the response body,
                            * which could be very long if there are no newlines in the HTML */
                            data = sr.ReadLine();
                        }
                    }
                }
                catch (IOException exceptIO)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, exceptIO, "Error with stream reading");
                }
            }
            dataCopy = data;
        }
        {
            string data = dataCopy;
            using (DirectoryEntry de = new DirectoryEntry())
            {
                /* POTENTIAL FLAW: data concatenated into LDAP search, which could result in LDAP Injection */
                using (DirectorySearcher search = new DirectorySearcher(de))
                {
                    search.Filter = "(&(objectClass=user)(employeename=" + data + "))";
                    search.PropertiesToLoad.Add("mail");
                    search.PropertiesToLoad.Add("telephonenumber");
                    SearchResult sresult = search.FindOne();
                }
            }
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        GoodG2B();
    }

    /* goodG2B() - use goodsource and badsink */
    private void GoodG2B()
    {
        string dataCopy;
        {
            string data;
            /* FIX: Use a hardcoded string */
            data = "foo";
            dataCopy = data;
        }
        {
            string data = dataCopy;
            using (DirectoryEntry de = new DirectoryEntry())
            {
                /* POTENTIAL FLAW: data concatenated into LDAP search, which could result in LDAP Injection */
                using (DirectorySearcher search = new DirectorySearcher(de))
                {
                    search.Filter = "(&(objectClass=user)(employeename=" + data + "))";
                    search.PropertiesToLoad.Add("mail");
                    search.PropertiesToLoad.Add("telephonenumber");
                    SearchResult sresult = search.FindOne();
                }
            }
        }
    }
#endif //omitgood
}
}
