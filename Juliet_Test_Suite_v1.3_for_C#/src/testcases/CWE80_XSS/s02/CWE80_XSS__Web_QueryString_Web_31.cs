/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE80_XSS__Web_QueryString_Web_31.cs
Label Definition File: CWE80_XSS__Web.label.xml
Template File: sources-sink-31.tmpl.cs
*/
/*
 * @description
 * CWE: 80 Cross Site Scripting (XSS)
 * BadSource: QueryString_Web Parse id param out of the URL query string (without using getParameter())
 * GoodSource: A hardcoded string
 * Sinks: Web
 *    BadSink : Display of data in web page without any encoding or validation
 * Flow Variant: 31 Data flow: make a copy of data within the same method
 *
 * */

using TestCaseSupport;
using System;

using System.Web;


namespace testcases.CWE80_XSS
{

class CWE80_XSS__Web_QueryString_Web_31 : AbstractTestCaseWeb
{
#if (!OMITBAD)
    /* uses badsource and badsink */
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        string dataCopy;
        {
            string data;
            data = ""; /* initialize data in case id is not in query string */
            /* POTENTIAL FLAW: Parse id param out of the URL querystring (without using getParameter()) */
            {
                if (req.QueryString["id"] != null)
                {
                    data = req.QueryString["id"];
                }
            }
            dataCopy = data;
        }
        {
            string data = dataCopy;
            if (data != null)
            {
                /* POTENTIAL FLAW: Display of data in web page without any encoding or validation */
                resp.Write("<br>Bad(): data = " + data);
            }
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good(HttpRequest req, HttpResponse resp)
    {
        GoodG2B(req, resp);
    }

    /* goodG2B() - use goodsource and badsink */
    private void GoodG2B(HttpRequest req, HttpResponse resp)
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
            if (data != null)
            {
                /* POTENTIAL FLAW: Display of data in web page without any encoding or validation */
                resp.Write("<br>Bad(): data = " + data);
            }
        }
    }
#endif //omitgood
}
}
