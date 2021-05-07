/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE400_Uncontrolled_Resource_Consumption__Get_Cookies_Web_write_54b.cs
Label Definition File: CWE400_Uncontrolled_Resource_Consumption.label.xml
Template File: sources-sinks-54b.tmpl.cs
*/
/*
 * @description
 * CWE: 400 Uncontrolled Resource Consumption
 * BadSource: Get_Cookies_Web Read count from the first cookie using Cookies
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: write
 *    GoodSink: Write to a file count number of times, but first validate count
 *    BadSink : Write to a file count number of times
 * Flow Variant: 54 Data flow: data passed as an argument from one method through three others to a fifth; all five functions are in different classes in the same package
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

using System.IO;

namespace testcases.CWE400_Uncontrolled_Resource_Consumption
{
class CWE400_Uncontrolled_Resource_Consumption__Get_Cookies_Web_write_54b
{
#if (!OMITBAD)
    public static void BadSink(int count , HttpRequest req, HttpResponse resp)
    {
        CWE400_Uncontrolled_Resource_Consumption__Get_Cookies_Web_write_54c.BadSink(count , req, resp);
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(int count , HttpRequest req, HttpResponse resp)
    {
        CWE400_Uncontrolled_Resource_Consumption__Get_Cookies_Web_write_54c.GoodG2BSink(count , req, resp);
    }

    /* goodB2G() - use badsource and goodsink */
    public static void GoodB2GSink(int count , HttpRequest req, HttpResponse resp)
    {
        CWE400_Uncontrolled_Resource_Consumption__Get_Cookies_Web_write_54c.GoodB2GSink(count , req, resp);
    }
#endif
}
}
